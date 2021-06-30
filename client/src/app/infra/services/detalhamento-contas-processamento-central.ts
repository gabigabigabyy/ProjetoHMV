import { nullSafeIsEquivalent } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { ContasProcessamentoCentral } from '../models/contas-processamento-central';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class DetalhamentoContasProcessamentoCentralService extends BaseService {
  
  public getLista(cdLocal: string) {
    return this.get<ContasProcessamentoCentral[]>('api/centralDeContasDePacientes/detalhesContasEmProcessamento/'+cdLocal);
  }

  public getDemaisContas(local: string) {
    return this.get<ContasProcessamentoCentral[]>('api/centralDeContasDePacientes/detalhesDemaisOrigens/'+local);
  }

  public getTotalContasProcessamento() {
    return this.get<ContasProcessamentoCentral[]>('api/centralDeContasDePacientes/detalhesTotalContasProcessamento')
    
  }

  public getTotalContasDemaisOrigens() {
    return this.get<ContasProcessamentoCentral[]>('api/centralDeContasDePacientes/detalhesTotalDemaisOrigens');
  }

  public getTotalContas() {
    return this.get<ContasProcessamentoCentral[]>('api/centralDeContasDePacientes/detalhesTotal');
  }

  public error(erro: string) {
    this.errorHandler(erro);
  }
}
