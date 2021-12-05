import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateIntroductionComponent } from './create-introduction.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {TagsService} from "../services/tags.service";
import {MatDialog} from "@angular/material/dialog";

describe('CreateIntroductionComponent', () => {
  let component: CreateIntroductionComponent;
  let fixture: ComponentFixture<CreateIntroductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateIntroductionComponent ],
      imports: [HttpClientTestingModule,ReactiveFormsModule,MatSnackBarModule, MatDialog],
      providers: [IntroductionRequestService,TagsService, MatDialog],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateIntroductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
/*
  it('should create', () => {
    expect(component).toBeTruthy();
  });*/
});
