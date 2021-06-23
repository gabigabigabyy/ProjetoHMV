import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NucleoContasCirurgicasComponent } from './nucleo-contas-cirurgicas.component';
import { AvisosConferenciaTecnicaComponent } from './avisos-conferencia-tecnica/avisos-conferencia-tecnica.component';
import { DetalhamentoAvisosConferenciaTecnicaComponent } from './detalhamento-avisos-conferencia-tecnica/detalhamento-avisos-conferencia-tecnica.component';
import { MaterialModule } from './../../shared/material/material.module';


@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [
    NucleoContasCirurgicasComponent,
    AvisosConferenciaTecnicaComponent,
    DetalhamentoAvisosConferenciaTecnicaComponent
  ],
  exports: [
    AvisosConferenciaTecnicaComponent,
    DetalhamentoAvisosConferenciaTecnicaComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class NucleoContasCirurgicasModule { }
