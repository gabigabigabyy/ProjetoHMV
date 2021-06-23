import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-monitoramento-boletins-sala',
  templateUrl: './monitoramento-boletins-sala.component.html',
  styleUrls: ['./monitoramento-boletins-sala.component.css']
})
export class MonitoramentoBoletinsSalaComponent implements OnInit {

  constructor(private headerService: HeaderService, private router: Router) {
    headerService.headerData = {
      title: 'Monitoramento de Boletins de Sala',
      icon: 'attach_money',
      routeUrlNavigation: '/monitoramentoDeBoletinsDeSala',
      lastRouteUrl: this.router.url,
      dataAtualizada: new Date()
    }
    this.headerService.RefreshPage(this.router.url);
  }

  ngOnInit(): void {
  }
}
