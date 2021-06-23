import { TestBed } from '@angular/core/testing';

import { ContasProcessamentoCentralService } from './contas-processamento-central.service';

describe('ContasProcessamentoCentralService', () => {
  let service: ContasProcessamentoCentralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContasProcessamentoCentralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
