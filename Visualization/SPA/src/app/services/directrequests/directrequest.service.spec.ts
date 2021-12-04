import { TestBed } from '@angular/core/testing';

import { DirectRequestService } from './direct-request.service';

describe('DirectrequestService', () => {
  let service: DirectRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DirectRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
