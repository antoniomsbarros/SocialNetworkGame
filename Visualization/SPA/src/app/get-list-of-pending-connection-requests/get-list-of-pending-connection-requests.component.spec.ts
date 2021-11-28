import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetListOfPendingConnectionRequestsComponent } from './get-list-of-pending-connection-requests.component';

describe('GetListOfPendingConnectionRequestsComponent', () => {
  let component: GetListOfPendingConnectionRequestsComponent;
  let fixture: ComponentFixture<GetListOfPendingConnectionRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetListOfPendingConnectionRequestsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetListOfPendingConnectionRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
