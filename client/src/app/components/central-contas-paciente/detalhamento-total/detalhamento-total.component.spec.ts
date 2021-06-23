import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoTotalComponent } from './detalhamento-total.component';

describe('DetalhamentoTotalComponent', () => {
  let component: DetalhamentoTotalComponent;
  let fixture: ComponentFixture<DetalhamentoTotalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoTotalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoTotalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
