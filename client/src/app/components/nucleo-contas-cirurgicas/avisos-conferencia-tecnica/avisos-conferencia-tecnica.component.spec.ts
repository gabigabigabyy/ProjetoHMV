import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvisosConferenciaTecnicaComponent } from './avisos-conferencia-tecnica.component';

describe('AvisosConferenciaTecnicaComponent', () => {
  let component: AvisosConferenciaTecnicaComponent;
  let fixture: ComponentFixture<AvisosConferenciaTecnicaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvisosConferenciaTecnicaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvisosConferenciaTecnicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
