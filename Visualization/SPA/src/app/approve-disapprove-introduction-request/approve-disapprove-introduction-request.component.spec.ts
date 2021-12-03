import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveDisapproveIntroductionRequestComponent } from './approve-disapprove-introduction-request.component';

describe('ApproveDisapproveIntroductionRequestComponent', () => {
  let component: ApproveDisapproveIntroductionRequestComponent;
  let fixture: ComponentFixture<ApproveDisapproveIntroductionRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveDisapproveIntroductionRequestComponent ]
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
