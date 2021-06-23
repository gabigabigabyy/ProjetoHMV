import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Portlet } from 'src/app/infra/models/portlet';
import { CirurgiasConfirmadasServiceService } from 'src/app/infra/services/cirurgias-confirmadas-service.service';

@Component({
  selector: 'app-cirurgias-confirmadas',
  templateUrl: './cirurgias-confirmadas.component.html',
  styleUrls: ['./cirurgias-confirmadas.component.css']
})
export class CirurgiasConfirmadasComponent implements OnInit {

  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<Portlet>();
  displayedColumns = ['descricao', 'quantidade', 'mediaDias', 'detalhes']

  constructor(private service: CirurgiasConfirmadasServiceService,
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
        this.service.error("Erro ao carregar lista de Cirurgias confirmadas!");
      });
  }

  public goToDetails(conta: Portlet) {
    this.router.navigate(['/detalhamentoCirurgiasConfirmadas/' + conta.codigo]);
  }

  private showLoading() {
    this.loading = true;
  }

  private hideLoading() {
    this.loading = false;
  }
}
