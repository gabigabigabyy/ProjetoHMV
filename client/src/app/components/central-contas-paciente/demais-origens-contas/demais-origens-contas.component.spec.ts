import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemaisOrigensContasComponent } from './demais-origens-contas.component';

describe('DemaisOrigensContasComponent', () => {
  let component: DemaisOrigensContasComponent;
  let fixture: ComponentFixture<DemaisOrigensContasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemaisOrigensContasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemaisOrigensContasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
