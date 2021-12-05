import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetListOfPendingConnectionRequestsComponent } from './get-list-of-pending-connection-requests.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSnackBar, MatSnackBarModule} from "@angular/material/snack-bar";
import {DebugElement, NO_ERRORS_SCHEMA} from "@angular/core";
import {AppComponent} from "../app.component";
import {IntroductionRequestService} from "../services/introduction-request.service";
import {TagsService} from "../services/tags.service";
import {ContentContainerComponentHarness} from "@angular/cdk/testing";
import {of} from "rxjs";

describe('GetListOfPendingConnectionRequestsComponent', () => {
  let component: GetListOfPendingConnectionRequestsComponent;
  let fixture: ComponentFixture<GetListOfPendingConnectionRequestsComponent>;
let tService: TagsService;
let iService: IntroductionRequestService;
 let p= IntroductionRequestService;

let spy: jasmine.Spy;
  let de: DebugElement;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetListOfPendingConnectionRequestsComponent,AppComponent ],
      imports: [HttpClientTestingModule,ReactiveFormsModule,MatSnackBarModule],
      providers: [IntroductionRequestService,TagsService],

    })
    .compileComponents();
    TestBed.createComponent(AppComponent);
    fixture=TestBed.createComponent(GetListOfPendingConnectionRequestsComponent);
    component=fixture.componentInstance;

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetListOfPendingConnectionRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    de=fixture.debugElement;
    tService=de.injector.get<TagsService>(TagsService);
    iService=de.injector.get<IntroductionRequestService>(IntroductionRequestService);


  //spy=spyOn(iService,"getIntroductionsPending" ).returnValue(of([]));
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should be unnedefined', () =>{
    expect(component.introductionRequestSelected).toBeUndefined()
  });
  it('should be empty', () =>{
    expect(component.allTags.length).toBe(0)
  });
  it('should be empty', () =>{
    expect(component.selectedItems.length).toBe(0)
  });
  it('should be empty', () =>{
    component.getPendingIntroductions()
    expect(component.allTags.length).toBe(0)
    expect(component.introductionRequestPending.length).toBe(0)
  });
 /* it('should ',  () =>{
     component.
  });*/
  it('should contain',  () =>{
    component.onItemSelect({item_text:"ola"});
    expect(component.selectedTags).toContain("ola")
  });
});
