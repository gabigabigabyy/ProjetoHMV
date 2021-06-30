
import { BrowserModule} from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { MaterialModule } from './shared/material/material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './shared/header/header.component';
import { NucleoContasCirurgicasModule } from './components/nucleo-contas-cirurgicas/nucleo-contas-cirurgicas.module';
import { FooterComponent } from './shared/footer/footer.component';
import { NavComponent } from './shared/nav/nav.component';
import { HttpClientModule } from  '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { DownloadService } from './infra/services/download.service';
import { DatePipe, registerLocaleData, CommonModule } from '@angular/common';
import { CentralContasPacienteModule } from './components/central-contas-paciente/central-contas-paciente.module';
import localeBr from '@angular/common/locales/br';
import { RefreshComponent } from './shared/refresh/refresh.component';
import { MonitoramentoBoletinsSalaModule } from './components/monitoramento-boletins-sala/monitoramento-boletins-sala.module';
import { ModalModule } from 'ngx-bootstrap/modal';



registerLocaleData(localeBr);

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    HomeComponent,
    RefreshComponent,
    
    
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NucleoContasCirurgicasModule,
    CentralContasPacienteModule,
    MonitoramentoBoletinsSalaModule,
    HttpClientModule,
    ModalModule.forRoot(),
    CommonModule,
    
    
  ],
  providers: [
    DownloadService, 
    DatePipe,
    { provide: LOCALE_ID, useValue: 'br-BR' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
