import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderService } from './../../infra/services/header.service';

@Component({
  selector: 'app-nucleo-contas-cirurgicas',
  templateUrl: './nucleo-contas-cirurgicas.component.html',
  styleUrls: ['./nucleo-contas-cirurgicas.component.css']
})
export class NucleoContasCirurgicasComponent implements OnInit {

  constructor(private headerService: HeaderService, private router: Router,) {
    headerService.headerData = {
      title: 'Núcleo de Contas Cirurgicas',
      icon: 'local_hospital',
      routeUrlNavigation: '/nucleoContasCirurgicas',
      lastRouteUrl: this.router.url,
      dataAtualizada: null
    }
  }

  ngOnInit(): void {
  }
}
