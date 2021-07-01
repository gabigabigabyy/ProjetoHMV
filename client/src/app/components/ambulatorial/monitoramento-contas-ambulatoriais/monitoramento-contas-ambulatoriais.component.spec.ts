import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MonitoramentoContasAmbulatoriaisComponent } from './monitoramento-contas-ambulatoriais.component';

describe('MonitoramentoContasAmbulatoriaisComponent', () => {
  let component: MonitoramentoContasAmbulatoriaisComponent;
  let fixture: ComponentFixture<MonitoramentoContasAmbulatoriaisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MonitoramentoContasAmbulatoriaisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MonitoramentoContasAmbulatoriaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
