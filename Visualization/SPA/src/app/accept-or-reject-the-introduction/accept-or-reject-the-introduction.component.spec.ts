import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptOrRejectTheIntroductionComponent } from './accept-or-reject-the-introduction.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {TagsService} from "../services/tags.service";

describe('AcceptOrRejectTheIntroductionComponent', () => {
  let component: AcceptOrRejectTheIntroductionComponent;
  let fixture: ComponentFixture<AcceptOrRejectTheIntroductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptOrRejectTheIntroductionComponent ],
      imports: [HttpClientTestingModule,],
      providers: [],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcceptOrRejectTheIntroductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
