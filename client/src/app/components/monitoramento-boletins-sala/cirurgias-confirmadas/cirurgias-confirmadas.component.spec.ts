import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CirurgiasConfirmadasComponent } from './cirurgias-confirmadas.component';

describe('CirurgiasConfirmadasComponent', () => {
  let component: CirurgiasConfirmadasComponent;
  let fixture: ComponentFixture<CirurgiasConfirmadasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CirurgiasConfirmadasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CirurgiasConfirmadasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
