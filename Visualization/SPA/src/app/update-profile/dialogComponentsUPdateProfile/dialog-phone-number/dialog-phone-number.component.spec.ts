import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogPhoneNumberComponent } from './dialog-phone-number.component';

describe('DialogPhoneNumberComponent', () => {
  let component: DialogPhoneNumberComponent;
  let fixture: ComponentFixture<DialogPhoneNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogPhoneNumberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogPhoneNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
