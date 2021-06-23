import { TestBed } from '@angular/core/testing';

import { ModalInfoService } from './modal-info.service';

describe('ModalInfoService', () => {
  let service: ModalInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ModalInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
