import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoTotalDemaisOrigensComponent } from './detalhamento-total-demais-origens.component';

describe('DetalhamentoTotalDemaisOrigensComponent', () => {
  let component: DetalhamentoTotalDemaisOrigensComponent;
  let fixture: ComponentFixture<DetalhamentoTotalDemaisOrigensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoTotalDemaisOrigensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoTotalDemaisOrigensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
