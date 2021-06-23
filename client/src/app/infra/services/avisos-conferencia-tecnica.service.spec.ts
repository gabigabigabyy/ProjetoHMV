import { TestBed } from '@angular/core/testing';

import { AvisosConferenciaTecnicaService } from './avisos-conferencia-tecnica.service';

describe('AvisosConferenciaTecnicaService', () => {
  let service: AvisosConferenciaTecnicaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvisosConferenciaTecnicaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
