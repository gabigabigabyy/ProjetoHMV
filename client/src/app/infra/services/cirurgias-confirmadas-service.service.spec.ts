import { TestBed } from '@angular/core/testing';

import { CirurgiasConfirmadasServiceService } from './cirurgias-confirmadas-service.service';

describe('CirurgiasConfirmadasServiceService', () => {
  let service: CirurgiasConfirmadasServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CirurgiasConfirmadasServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
