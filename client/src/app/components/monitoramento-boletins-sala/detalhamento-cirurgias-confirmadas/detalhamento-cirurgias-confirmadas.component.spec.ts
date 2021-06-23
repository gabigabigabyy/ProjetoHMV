import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesCirurgiasConfirmadasComponent } from './detalhes-cirurgias-confirmadas.component';

describe('DetalhesCirurgiasConfirmadasComponent', () => {
  let component: DetalhesCirurgiasConfirmadasComponent;
  let fixture: ComponentFixture<DetalhesCirurgiasConfirmadasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhesCirurgiasConfirmadasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesCirurgiasConfirmadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
