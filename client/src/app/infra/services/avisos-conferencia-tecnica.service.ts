import { Portlet } from './../models/portlet';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AvisosConferenciaTecnicaService extends BaseService{

  public getLista()  {
    return this.get<Portlet[]>("api/nucleoDeContasCirurgicas/avisosConferenciaTecnica");
  }

  public error(erro: string){
    this.errorHandler(erro);
  }
}
