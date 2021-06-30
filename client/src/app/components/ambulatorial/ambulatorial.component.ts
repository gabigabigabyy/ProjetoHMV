import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderService } from 'src/app/infra/services/header.service';

@Component({
  selector: 'app-ambulatorial',
  templateUrl: './ambulatorial.component.html',
  styleUrls: ['./ambulatorial.component.css']
  
})
export class AmbulatorialComponent implements OnInit {


      constructor(private headerService: HeaderService, private router: Router ) { 
      headerService.headerData = {
        title: 'Núcleo de Contas Ambulatoriais',
        icon: 'healing',
        routeUrlNavigation: '/nucleoContasAmbulatoriais',
        lastRouteUrl: this.router.url,
        dataAtualizada: null
      }
      this.headerService.RefreshPage(this.router.url);
  }

  ngOnInit(): void {
  }

}
