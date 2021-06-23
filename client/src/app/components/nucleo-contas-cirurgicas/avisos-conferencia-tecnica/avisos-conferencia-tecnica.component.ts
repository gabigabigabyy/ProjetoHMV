import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Portlet } from 'src/app/infra/models/portlet';
import { AvisosConferenciaTecnicaService } from 'src/app/infra/services/avisos-conferencia-tecnica.service';

@Component({
  selector: 'app-avisos-conferencia-tecnica',
  templateUrl: './avisos-conferencia-tecnica.component.html',
  styleUrls: ['./avisos-conferencia-tecnica.component.css']
})
export class AvisosConferenciaTecnicaComponent implements OnInit {

  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<Portlet>();
  displayedColumns = ['descricao', 'quantidade', 'mediaDias', 'detalhes']

  constructor(private service: AvisosConferenciaTecnicaService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadDataSource();
  }

  private loadDataSource() {
    this.showLoading();
    this.service.getLista().subscribe(list => {
      this.dataSource.data = list;
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

  public goToDetails() {
    this.router.navigate(['/detalhamentoAvisosConferenciaTecnica']);
  }

  private showLoading() {
    this.loading = true;
  }

  private hideLoading() {
    this.loading = false;
  }
}
