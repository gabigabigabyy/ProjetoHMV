import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Header } from '../models/header';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  private _headerData = new BehaviorSubject<Header>({
    title: 'Início',
    icon: 'home',
    routeUrlNavigation: '',
    lastRouteUrl: '',
    dataAtualizada: null
  })

  constructor(private router: Router) { }

  get headerData(): Header {
    return this._headerData.value
  }

  set headerData(headerData: Header) {
    this._headerData.next(headerData)
  }

  public RefreshPage(rota: string) {
    setTimeout(() => {
      if (this.headerData.lastRouteUrl == rota) {
        this.router.navigateByUrl('/refresh', { skipLocationChange: true }).then(() => {
          this.router.navigate([rota]);
        });
      }
    }, 300000);
  }
}
