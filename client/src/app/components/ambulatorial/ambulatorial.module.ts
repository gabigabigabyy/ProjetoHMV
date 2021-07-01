import { AmbulatorialComponent } from './ambulatorial.component';
import { MonitoramentoContasAmbulatoriaisComponent } from './monitoramento-contas-ambulatoriais/monitoramento-contas-ambulatoriais.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { SinaleirasModule } from 'src/app/shared/sinaleiras/sinaleiras.module';



@NgModule({
  declarations: [
  MonitoramentoContasAmbulatoriaisComponent,
  AmbulatorialComponent],
  imports: [
    CommonModule,
    MaterialModule,
    SinaleirasModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AmbulatorialModule { }
