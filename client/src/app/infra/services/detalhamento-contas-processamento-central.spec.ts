import { TestBed } from '@angular/core/testing';

import { DetalhamentoContasProcessamentoCentralService } from './detalhamento-contas-processamento-central';

describe('DetalhamentoContasProcessamentoCentralService', () => {
    let service: DetalhamentoContasProcessamentoCentralService;
  
    beforeEach(() => {
      TestBed.configureTestingModule({});
      service = TestBed.inject(DetalhamentoContasProcessamentoCentralService);
    });
  
    it('should be created', () => {
      expect(service).toBeTruthy();
    });
  });