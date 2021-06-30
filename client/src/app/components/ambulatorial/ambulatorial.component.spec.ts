import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmbulatorialComponent } from './ambulatorial.component';

describe('AmbulatorialComponent', () => {
  let component: AmbulatorialComponent;
  let fixture: ComponentFixture<AmbulatorialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmbulatorialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmbulatorialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
