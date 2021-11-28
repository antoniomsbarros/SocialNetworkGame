import { TestBed } from '@angular/core/testing';

import { IntroductionRequestService } from './introduction-request.service';

describe('IntroductionRequestService', () => {
  let service: IntroductionRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IntroductionRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
