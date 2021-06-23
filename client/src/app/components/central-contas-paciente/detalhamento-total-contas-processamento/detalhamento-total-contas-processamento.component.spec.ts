import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoTotalContasProcessamentoComponent } from "./DetalhamentoTotalContasProcessamentoComponent";

describe('DetalhamentoTotalContasProcessamentoComponent', () => {
  let component: DetalhamentoTotalContasProcessamentoComponent;
  let fixture: ComponentFixture<DetalhamentoTotalContasProcessamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoTotalContasProcessamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoTotalContasProcessamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
