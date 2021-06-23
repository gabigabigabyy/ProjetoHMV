import { Injectable } from '@angular/core';
import { AvisoCirurgia } from '../models/aviso-cirurgia';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class DetalhamentoAvisosConferenciaTecnicaService extends BaseService {

  public getLista() {
    return this.get<AvisoCirurgia[]>("api/nucleoDeContasCirurgicas/detalhesAvisosConferenciaTecnica");
  }

  public error(erro: string) {
    this.errorHandler(erro);
  }
}
