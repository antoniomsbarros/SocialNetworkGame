import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPendingDirectRequestsComponent } from './get-pending-direct-requests.component';

describe('GetPendingDirectRequestsComponent', () => {
  let component: GetPendingDirectRequestsComponent;
  let fixture: ComponentFixture<GetPendingDirectRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetPendingDirectRequestsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetPendingDirectRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
