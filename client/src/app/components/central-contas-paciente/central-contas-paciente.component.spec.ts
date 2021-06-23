import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CentralContasPacienteComponent } from './central-contas-paciente.component';

describe('CentralContasPacienteComponent', () => {
  let component: CentralContasPacienteComponent;
  let fixture: ComponentFixture<CentralContasPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CentralContasPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CentralContasPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});