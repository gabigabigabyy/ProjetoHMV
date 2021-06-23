import { Component, OnInit } from '@angular/core';
import { HeaderService } from './../../infra/services/header.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private headerService: HeaderService) { }

  ngOnInit(): void {
    //this.headerService.dataAtualizada  = new Date().toLocaleTimeString('pt-BR');
  }

  get title(): string {
    return this.headerService.headerData.title
  }

  get icon(): string {
    return this.headerService.headerData.icon
  }

  get routeUrlNavigation(): string {
    return this.headerService.headerData.routeUrlNavigation
  }

  get lastRouteUrl(): string {
    return this.headerService.headerData.lastRouteUrl
  }

  get dataAtualizada(): string {
    let dataAtualizada: string;
    if (this.headerService.headerData.dataAtualizada != null) {
      dataAtualizada = "Atualizado às " + this.headerService.headerData.dataAtualizada.toLocaleTimeString()
    }
    return dataAtualizada;
  }
}
