import { TestBed } from '@angular/core/testing';

import { DetalhesCirurgiasConfirmadasService } from './detalhamento-cirurgias-confirmadas.service';

describe('DetalhesCirurgiasConfirmadasService', () => {
  let service: DetalhesCirurgiasConfirmadasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DetalhesCirurgiasConfirmadasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
