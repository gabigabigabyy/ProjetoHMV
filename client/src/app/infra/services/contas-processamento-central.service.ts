import { Injectable } from '@angular/core';
import { PortletCentralContasPaciente } from '../models/portlet-central-contas-paciente';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ContasProcessamentoCentralService extends BaseService{

  public getLista()  {
    return this.get<PortletCentralContasPaciente[]>("api/centralDeContasDePacientes/contasEmProcessamento");
  }

  public getDemaisContas(){
    return this.get<PortletCentralContasPaciente[]>("api/centralDeContasDePacientes/demaisOrigens");
  }

  public getTotal(){
    return this.get<PortletCentralContasPaciente[]>("api/centralDeContasDePacientes/totalDeContas");
  }

  public error(erro: string){
    this.errorHandler(erro);
  }

}
