import { Injectable } from '@angular/core';
import { CirurgiasConfirmadas } from '../models/cirurgias-confirmadas';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class DetalhesCirurgiasConfirmadasService extends BaseService{

  public getLista(codigoCentroCirurgico: number) {
    return this.get<CirurgiasConfirmadas[]>("api/centralDeContasDePacientes/detalhamentoCirurgiasConfirmadas/"+codigoCentroCirurgico);
  }

  public error(erro: string) {
    this.errorHandler(erro);
  }
}
