import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SinaleirasComponent } from './sinaleiras.component';

describe('SinaleirasComponent', () => {
  let component: SinaleirasComponent;
  let fixture: ComponentFixture<SinaleirasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SinaleirasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SinaleirasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
