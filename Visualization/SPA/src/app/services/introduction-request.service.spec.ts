import { TestBed } from '@angular/core/testing';

import { IntroductionRequestService } from './introduction-request.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {TagsService} from "./tags.service";

describe('IntroductionRequestService', () => {
  let service: IntroductionRequestService;
  let  httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [HttpClientTestingModule],
      providers: [IntroductionRequestService]});
    service = TestBed.inject(IntroductionRequestService);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

    describe("#getIntroductionPending",()=>{



      it('returned Observable should match the right data ',  ()=> {

        const client="1200607@isep.ipp.pt";
        service.getIntroductionsPending(client).subscribe(data=>{
          console.log(data);
          expect(data).toBe([])
        })

      });
    })

});
