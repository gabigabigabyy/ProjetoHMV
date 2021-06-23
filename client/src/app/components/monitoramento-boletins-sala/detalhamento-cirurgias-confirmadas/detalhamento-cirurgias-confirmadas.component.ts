import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { CirurgiasConfirmadas } from 'src/app/infra/models/cirurgias-confirmadas';
import { DetalhesCirurgiasConfirmadasService } from 'src/app/infra/services/detalhamento-cirurgias-confirmadas.service';
import { DownloadService } from 'src/app/infra/services/download.service';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-detalhamento-cirurgias-confirmadas',
  templateUrl: './detalhamento-cirurgias-confirmadas.component.html',
  styleUrls: ['./detalhamento-cirurgias-confirmadas.component.css']
})
export class DetalhamentoCirurgiasConfirmadasComponent implements OnInit {

  listaAtendimentos: any;
  codigoCentroCirurgico: number;
  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<CirurgiasConfirmadas>();
  displayedColumns: string[] = [
    'codigoAtendimento',
    'tipoAtendimento',
    'paciente',
    'avisoCirurgia',
    'centroCirurgico',
    'dataAtendimento',
    'dataCirurgia',
    'dataAlta',
    'convenio',
    'quantidadeDiasFim'
  ];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private service: DetalhesCirurgiasConfirmadasService,
    private download: DownloadService,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe,
    private headerService: HeaderService) {

    this.activeRoute.params
      .subscribe(params => {
        this.codigoCentroCirurgico = (params['codigo']);
      });

    headerService.headerData.dataAtualizada = new Date();
    headerService.headerData.lastRouteUrl = this.router.url;
    this.headerService.RefreshPage(this.router.url);
  }

  ngOnInit() {
    this.loadDataSource();
    this.getAtendimentos();
  }

  private loadDataSource() {
    this.showLoading();
    this.service.getLista(this.codigoCentroCirurgico).subscribe(list => {
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
        this.service.error("Erro ao carregar lista de Cirurgias confirmadas!");
      });
  }

  private showLoading() {
    this.loading = true;
  }

  private hideLoading() {
    this.loading = false;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public close() {
    this.router.navigate([this.headerService.headerData.routeUrlNavigation]);
  }

  getAtendimentos() {
    var atendimentos = this.service.getLista(this.codigoCentroCirurgico).subscribe(atendimentos => {
      this.listaAtendimentos = atendimentos;
      this.formatDates(this.listaAtendimentos);
      if (atendimentos.length === 0) {
        this.noData = true;
      }
    },
      erro => {
        this.noData = true;
        this.service.error("Erro ao carregar lista de de Cirurgias confirmadas!");
      });
  }

  private formatDates(lista: any): any {
    lista.forEach(atendimento => {
      atendimento.dataAtendimento = this.datePipe.transform(atendimento.dataAtendimento, "dd/MM/yyyy");
      atendimento.dataCirurgia = this.datePipe.transform(atendimento.dataCirurgia, "dd/MM/yyyy");
      atendimento.dataAlta = atendimento.dataAlta == "0001-01-01T00:00:00" || "" ? "" : this.datePipe.transform(atendimento.dataAlta, "dd/MM/yyyy");
    });
  }

  exportAsXLSX(): void {
    this.download.exportAsExcelFile(this.listaAtendimentos, 'detalhamento-cirurgias-confirmadas');
  }

}
