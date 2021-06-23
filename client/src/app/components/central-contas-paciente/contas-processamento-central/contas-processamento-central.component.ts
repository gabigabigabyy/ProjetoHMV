import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { PortletCentralContasPaciente } from 'src/app/infra/models/portlet-central-contas-paciente';
import { ContasProcessamentoCentralService } from 'src/app/infra/services/contas-processamento-central.service';

@Component({
  selector: 'app-contas-processamento-central',
  templateUrl: './contas-processamento-central.component.html',
  styleUrls: ['./contas-processamento-central.component.css']
})
export class ContasProcessamentoCentralComponent implements OnInit {

  loading: boolean;
  noData: boolean;
  dataSource = new MatTableDataSource<PortletCentralContasPaciente>();
  displayedColumns = ['local', 'valor', 'quantidade', 'mediaDias', 'detalhes']


  constructor(private service: ContasProcessamentoCentralService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadDataSource();
  }

  private loadDataSource() {
    this.showLoading();
    var teste = this.service.getLista().subscribe(list => {
      this.dataSource.data = list;
      this.hideLoading();
      if (list.length === 0) {
        this.noData = true;
      }
    },
      erro => {
        this.hideLoading();
        this.noData = true;
        this.service.error("Erro ao arregar a Lista de Avisos de Conferência Técnica!");
      });
  }

  public goToDetails(conta: PortletCentralContasPaciente) {
    if (conta.local != "TOTAL") {
      this.router.navigate(['/detalhamentoCentralContasPacientes/' + conta.local]);
    } else {
      this.router.navigate(['/detalhamentoTotalContasProcessamento/']);
    }
  }

  private showLoading() {
    this.loading = true;
  }

  private hideLoading() {
    this.loading = false;
  }

}
