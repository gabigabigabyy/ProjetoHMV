import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhamentoDemaisOrigensContasComponent } from './detalhamento-demais-origens-contas.component';

describe('DetalhamentoDemaisOrigensContasComponent', () => {
  let component: DetalhamentoDemaisOrigensContasComponent;
  let fixture: ComponentFixture<DetalhamentoDemaisOrigensContasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhamentoDemaisOrigensContasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhamentoDemaisOrigensContasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
