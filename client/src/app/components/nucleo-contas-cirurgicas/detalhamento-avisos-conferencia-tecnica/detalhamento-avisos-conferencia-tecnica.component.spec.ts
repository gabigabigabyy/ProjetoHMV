import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoAvisosConferenciaTecnicaComponent } from './detalhamento-avisos-conferencia-tecnica.component';

describe('DetalhamentoAvisosConferenciaTecnicaComponent', () => {
  let component: DetalhamentoAvisosConferenciaTecnicaComponent;
  let fixture: ComponentFixture<DetalhamentoAvisosConferenciaTecnicaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoAvisosConferenciaTecnicaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoAvisosConferenciaTecnicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
