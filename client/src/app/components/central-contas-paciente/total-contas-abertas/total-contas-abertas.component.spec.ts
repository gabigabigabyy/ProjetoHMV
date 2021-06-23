import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalContasAbertasComponent } from './total-contas-abertas.component';

describe('TotalContasAbertasComponent', () => {
  let component: TotalContasAbertasComponent;
  let fixture: ComponentFixture<TotalContasAbertasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalContasAbertasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalContasAbertasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
