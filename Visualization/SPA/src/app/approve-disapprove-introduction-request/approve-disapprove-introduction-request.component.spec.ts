import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveDisapproveIntroductionRequestComponent } from './approve-disapprove-introduction-request.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {TagsService} from "../services/tags.service";

describe('ApproveDisapproveIntroductionRequestComponent', () => {
  let component: ApproveDisapproveIntroductionRequestComponent;
  let fixture: ComponentFixture<ApproveDisapproveIntroductionRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveDisapproveIntroductionRequestComponent ],
      imports: [HttpClientTestingModule,ReactiveFormsModule,MatSnackBarModule],
      providers: [IntroductionRequestService,TagsService],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproveDisapproveIntroductionRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
