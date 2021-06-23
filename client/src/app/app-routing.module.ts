import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { NucleoContasCirurgicasComponent } from './components/nucleo-contas-cirurgicas/nucleo-contas-cirurgicas.component';
import { DetalhamentoAvisosConferenciaTecnicaComponent } from './components/nucleo-contas-cirurgicas/detalhamento-avisos-conferencia-tecnica/detalhamento-avisos-conferencia-tecnica.component';
import { CentralContasPacienteComponent } from './components/central-contas-paciente/central-contas-paciente.component';
import { DetalhamentoContasProcessamentoCentralComponent } from './components/central-contas-paciente/detalhamento-contas-processamento-central/detalhamento-contas-processamento-central.component';
import { DetalhamentoDemaisOrigensContasComponent } from './components/central-contas-paciente/detalhamento-demais-origens-contas/detalhamento-demais-origens-contas.component';
import { DetalhamentoTotalComponent } from './components/central-contas-paciente/detalhamento-total/detalhamento-total.component';
import { DetalhamentoTotalContasProcessamentoComponent } from './components/central-contas-paciente/detalhamento-total-contas-processamento/detalhamento-total-contas-processamento.component';
import { DetalhamentoTotalDemaisOrigensComponent } from './components/central-contas-paciente/detalhamento-total-demais-origens/detalhamento-total-demais-origens.component';
import { RefreshComponent} from './shared/refresh/refresh.component'
import { MonitoramentoBoletinsSalaComponent } from './components/monitoramento-boletins-sala/monitoramento-boletins-sala.component';
import { DetalhamentoCirurgiasConfirmadasComponent } from './components/monitoramento-boletins-sala/detalhamento-cirurgias-confirmadas/detalhamento-cirurgias-confirmadas.component';

export const routes: Routes = [
    { path: "", component: HomeComponent },
    { path: "nucleoContasCirurgicas", component: NucleoContasCirurgicasComponent },
    { path: "detalhamentoAvisosConferenciaTecnica", component: DetalhamentoAvisosConferenciaTecnicaComponent },
    { path: "centralContasPaciente", component: CentralContasPacienteComponent },
    { path: "detalhamentoCentralContasPacientes/:local", component: DetalhamentoContasProcessamentoCentralComponent },
    { path: "detalhamentoDemaisOrigens/:local", component: DetalhamentoDemaisOrigensContasComponent },
    { path: "detalhamentoTotalContasAbertas", component: DetalhamentoTotalComponent },
    { path: "detalhamentoTotalContasProcessamento", component: DetalhamentoTotalContasProcessamentoComponent, },
    { path: "detalhamentoTotalDemaisOrigens", component: DetalhamentoTotalDemaisOrigensComponent, },
    { path: "refresh", component: RefreshComponent, },
    { path: "monitoramentoDeBoletinsDeSala", component: MonitoramentoBoletinsSalaComponent, },
    { path: "detalhamentoCirurgiasConfirmadas/:codigo", component: DetalhamentoCirurgiasConfirmadasComponent, }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }