import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { PortletCentralContasPaciente } from 'src/app/infra/models/portlet-central-contas-paciente';
import { ContasProcessamentoCentralService } from 'src/app/infra/services/contas-processamento-central.service';

@Component({
  selector: 'app-total-contas-abertas',
  templateUrl: './total-contas-abertas.component.html',
  styleUrls: ['./total-contas-abertas.component.css']
})
export class TotalContasAbertasComponent implements OnInit {

  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<PortletCentralContasPaciente>();
  displayedColumns = ['local', 'valor', 'quantidade', 'Detalhes']


  constructor(private service: ContasProcessamentoCentralService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadDataSource();
  }

  private loadDataSource() {
    this.showLoading();
    this.service.getTotal().subscribe(totalContas => {
      this.dataSource.data = totalContas;
      this.hideLoading();
      if (totalContas.length === 0) {
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
    this.router.navigate(['/detalhamentoTotalContasAbertas']);
  }

  private showLoading() {
    this.loading = true;
  }

  private hideLoading() {
    this.loading = false;
  }
}
