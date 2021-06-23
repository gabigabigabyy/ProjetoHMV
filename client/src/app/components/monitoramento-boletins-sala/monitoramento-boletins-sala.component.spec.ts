import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MonitoramentoBoletinsSalaComponent } from './monitoramento-boletins-sala.component';

describe('MonitoramentoBoletinsSalaComponent', () => {
  let component: MonitoramentoBoletinsSalaComponent;
  let fixture: ComponentFixture<MonitoramentoBoletinsSalaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MonitoramentoBoletinsSalaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MonitoramentoBoletinsSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
