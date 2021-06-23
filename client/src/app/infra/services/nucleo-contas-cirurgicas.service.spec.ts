import { TestBed } from '@angular/core/testing';

import { NucleoContasCirurgicasService } from './nucleo-contas-cirurgicas.service';

describe('NucleoContasCirurgicasService', () => {
  let service: NucleoContasCirurgicasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NucleoContasCirurgicasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
