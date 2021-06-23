import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoContasProcessamentoCentralComponent } from './detalhamento-contas-processamento-central.component';

describe('DetalhamentoContasProcessamentoCentralComponent', () => {
  let component: DetalhamentoContasProcessamentoCentralComponent;
  let fixture: ComponentFixture<DetalhamentoContasProcessamentoCentralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoContasProcessamentoCentralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoContasProcessamentoCentralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
