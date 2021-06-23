import { TestBed } from '@angular/core/testing';

import { DetalhamentoAvisosConferenciaTecnicaService } from './detalhamento-avisos-conferencia-tecnica.service';

describe('DetalhamentoAvisosConferenciaTecnicaService', () => {
  let service: DetalhamentoAvisosConferenciaTecnicaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DetalhamentoAvisosConferenciaTecnicaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
