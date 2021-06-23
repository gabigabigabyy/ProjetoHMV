import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NucleoContasCirurgicasComponent } from './nucleo-contas-cirurgicas.component';

describe('NucleoContasCirurgicasComponent', () => {
  let component: NucleoContasCirurgicasComponent;
  let fixture: ComponentFixture<NucleoContasCirurgicasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NucleoContasCirurgicasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NucleoContasCirurgicasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
