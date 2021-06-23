import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { MonitoramentoBoletinsSalaComponent } from './monitoramento-boletins-sala.component';
import { NucleoContasCirurgicasModule } from '../nucleo-contas-cirurgicas/nucleo-contas-cirurgicas.module';
import { CirurgiasConfirmadasComponent } from './cirurgias-confirmadas/cirurgias-confirmadas.component';
import { DetalhamentoCirurgiasConfirmadasComponent } from './detalhamento-cirurgias-confirmadas/detalhamento-cirurgias-confirmadas.component';

@NgModule({
  declarations: [
    MonitoramentoBoletinsSalaComponent,
    CirurgiasConfirmadasComponent,
    DetalhamentoCirurgiasConfirmadasComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    NucleoContasCirurgicasModule
  ]
})
export class MonitoramentoBoletinsSalaModule { }
