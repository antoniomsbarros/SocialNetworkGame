import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NetworkListingComponent } from './network-listing.component';

describe('NetworkListingComponent', () => {
  let component: NetworkListingComponent;
  let fixture: ComponentFixture<NetworkListingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NetworkListingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NetworkListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
