import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-central-contas-paciente',
  templateUrl: './central-contas-paciente.component.html',
  styleUrls: ['./central-contas-paciente.component.css']
})
export class CentralContasPacienteComponent implements OnInit {

  currentRoute: string;

  constructor(private headerService: HeaderService, private router: Router) {
    headerService.headerData = {
      title: 'Central de Contas do Paciente',
      icon: 'attach_money',
      routeUrlNavigation: '/centralContasPaciente',
      lastRouteUrl: this.router.url,
      dataAtualizada: new Date()
    }
    this.headerService.RefreshPage(this.router.url);
  }

  ngOnInit(): void {
  }
}