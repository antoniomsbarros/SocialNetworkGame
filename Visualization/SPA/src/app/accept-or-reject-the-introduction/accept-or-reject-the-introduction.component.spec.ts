import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptOrRejectTheIntroductionComponent } from './accept-or-reject-the-introduction.component';

describe('AcceptOrRejectTheIntroductionComponent', () => {
  let component: AcceptOrRejectTheIntroductionComponent;
  let fixture: ComponentFixture<AcceptOrRejectTheIntroductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptOrRejectTheIntroductionComponent ]
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
