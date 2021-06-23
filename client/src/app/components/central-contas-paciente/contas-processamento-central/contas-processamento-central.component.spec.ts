import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContasProcessamentoCentralComponent } from './contas-processamento-central.component';

describe('ContasProcessamentoCentralComponent', () => {
  let component: ContasProcessamentoCentralComponent;
  let fixture: ComponentFixture<ContasProcessamentoCentralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContasProcessamentoCentralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContasProcessamentoCentralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
