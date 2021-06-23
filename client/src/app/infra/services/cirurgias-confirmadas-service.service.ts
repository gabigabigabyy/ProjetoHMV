import { Portlet } from 'src/app/infra/models/portlet';
import { Injectable } from '@angular/core';
import { CirurgiasConfirmadas } from '../models/cirurgias-confirmadas';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CirurgiasConfirmadasServiceService extends BaseService {

  public getLista() {
    return this.get<Portlet[]>("api/centralDeContasDePacientes/cirurgiasConfirmadas");
  }

  public error(erro: string) {
    this.errorHandler(erro);
  }
}
