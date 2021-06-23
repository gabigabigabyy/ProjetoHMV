import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { AvisoCirurgia } from 'src/app/infra/models/aviso-cirurgia';
import { DetalhamentoAvisosConferenciaTecnicaService } from 'src/app/infra/services/detalhamento-avisos-conferencia-tecnica.service';
import { Router } from '@angular/router';
import { DownloadService } from '../../../infra/services/download.service';
import { DatePipe } from '@angular/common';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-detalhamento-avisos-conferencia-tecnica',
  templateUrl: './detalhamento-avisos-conferencia-tecnica.component.html',
  styleUrls: ['./detalhamento-avisos-conferencia-tecnica.component.css']
})
export class DetalhamentoAvisosConferenciaTecnicaComponent implements OnInit {

  listaAtendimentos: any;
  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<AvisoCirurgia>();
  displayedColumns: string[] = [
    'tipoAtendimento',
    'nomePaciente',
    'idConvenio',
    'convenio',
    'avisoCirurgia',
    'centroCirurgico',
    'dataAtendimento',
    'dataCirurgia',
    'dataAlta',
    'nomeUsuario',
    'retornos',
    'diasFim',
    'diasLocalAtual',
    'porteCirurgico',
    'cirurgiaoPrincipal'
  ];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private service: DetalhamentoAvisosConferenciaTecnicaService,
    private download: DownloadService,
    private router: Router,
    private datePipe: DatePipe,
    private headerService: HeaderService) {

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
    this.service.getLista().subscribe(list => {
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
        this.service.error("Erro ao carregar lista de Avisos de conferencia tecnica!");
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
    var atendimentos = this.service.getLista().subscribe(atendimentos => {
      this.listaAtendimentos = atendimentos;
      this.formatDates(this.listaAtendimentos);
      if (atendimentos.length === 0) {
        this.noData = true;
      }
    },
      erro => {
        this.noData = true;
        this.service.error("Erro ao carregar lista de Avisos de conferencia tecnica!");
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
    this.download.exportAsExcelFile(this.listaAtendimentos, 'detalhamento-avisos-conferencia-tecnica');
  }
}