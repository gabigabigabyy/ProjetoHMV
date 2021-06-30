import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ContasProcessamentoCentral } from 'src/app/infra/models/contas-processamento-central';
import { ConverterDataPipe } from 'src/app/infra/pipes/data-filter';
import { DetalhamentoContasProcessamentoCentralService } from 'src/app/infra/services/detalhamento-contas-processamento-central';
import { DownloadService } from 'src/app/infra/services/download.service';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-detalhamento-total-demais-origens',
  templateUrl: './detalhamento-total-demais-origens.component.html',
  styleUrls: ['./detalhamento-total-demais-origens.component.css'],
  providers: [
    ConverterDataPipe
  ]
})
export class DetalhamentoTotalDemaisOrigensComponent implements OnInit {

  listaContas: any;
  cdLocal: string;
  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<ContasProcessamentoCentral>();
  displayedColumns: string[] = [
    'unidadeInternacao',
    'atendimento',
    'avisoCirurgia',
    'paciente',
    'conta',
    'nroRetornos',
    'diasLocalAtual',
    'nomeUsuario',
    'dataInicial',
    'dataFinal',
    'dataAlta',
    'qtdDiasFim',
    'convenio',
    'valor',
    'status'
  ];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private service: DetalhamentoContasProcessamentoCentralService,
    private download: DownloadService,
    private router: Router,
    private datePipe: DatePipe,
    private activeRoute: ActivatedRoute,
    private formatarData: ConverterDataPipe,
    private headerService: HeaderService) {

    headerService.headerData.dataAtualizada = new Date();
    headerService.headerData.lastRouteUrl = this.router.url;
   /*  this.headerService.RefreshPage(this.router.url); */
  }

  ngOnInit() {
    this.loadDataSource();
    this.getContas();
  }

  private showLoading() {
    this.loading = true;
  }

  private loadDataSource() {
    this.showLoading();
    this.service.getTotalContasDemaisOrigens().subscribe(list => {
      this.formatDates(list);
      this.dataSource.data = list;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.hideLoading();
      if (list.length === 0) {
        this.noData = true;
      }
    },
      erro => {
        this.hideLoading();
        this.noData = true;
        this.service.error("Erro ao carregar lista de contas!");
      });
  }

  private hideLoading() {
    this.loading = false;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public goCentralDeContasDePacientes() {
    this.router.navigate(['/centralContasPaciente']);
  }

  getContas() {
    var contas = this.service.getTotalContasDemaisOrigens().subscribe(contas => {
      this.formatDates(contas);
      this.removeColumns(contas);
      this.listaContas = contas;
      if (contas.length === 0) {
        this.noData = true;
      }
    },
      erro => {
        this.noData = true;
        this.service.error("Erro ao carregar lista de contas!");
      });
  }

  private formatDates(lista: any) {
    lista.forEach(atendimento => {
      atendimento.dataInicial = this.formatarData.transform(atendimento.dataInicial);
      atendimento.dataAlta = this.formatarData.transform(atendimento.dataAlta);
      atendimento.dataFinal = this.formatarData.transform(atendimento.dataFinal);
    });
  }

  private removeColumns(lista: any) {
    lista.forEach(conta => {
      delete conta.status
      delete conta.quantidade;
    });
  }

  exportAsXLSX(): void {
    this.download.exportAsExcelFile(this.listaContas, 'total-contas-abertas-p-1037');
  }
}
