import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CentralContasPacienteComponent } from './central-contas-paciente.component';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { ContasProcessamentoCentralComponent } from './contas-processamento-central/contas-processamento-central.component';
import { DetalhamentoContasProcessamentoCentralComponent } from './detalhamento-contas-processamento-central/detalhamento-contas-processamento-central.component';
import { ConverterDataPipe } from 'src/app/infra/pipes/data-filter';
import { DemaisOrigensContasComponent } from './demais-origens-contas/demais-origens-contas.component';
import { DetalhamentoDemaisOrigensContasComponent } from './detalhamento-demais-origens-contas/detalhamento-demais-origens-contas.component';
import { TotalContasAbertasComponent } from './total-contas-abertas/total-contas-abertas.component';
import { DetalhamentoTotalComponent } from './detalhamento-total/detalhamento-total.component';
import { DetalhamentoTotalContasProcessamentoComponent } from './detalhamento-total-contas-processamento/detalhamento-total-contas-processamento.component';
import { DetalhamentoTotalDemaisOrigensComponent } from './detalhamento-total-demais-origens/detalhamento-total-demais-origens.component';
import { SinaleirasModule } from 'src/app/shared/sinaleiras/sinaleiras.module';

@NgModule({
  declarations: [
    CentralContasPacienteComponent, 
    ContasProcessamentoCentralComponent,
    TotalContasAbertasComponent,
    DetalhamentoContasProcessamentoCentralComponent,
    DemaisOrigensContasComponent,
    DetalhamentoDemaisOrigensContasComponent,
    DetalhamentoTotalComponent,
    DetalhamentoTotalContasProcessamentoComponent,
    DetalhamentoTotalDemaisOrigensComponent,
    ConverterDataPipe
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SinaleirasModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CentralContasPacienteModule { }