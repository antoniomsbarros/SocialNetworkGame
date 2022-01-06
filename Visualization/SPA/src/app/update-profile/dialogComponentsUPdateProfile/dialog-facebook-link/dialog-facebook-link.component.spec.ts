import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogFacebookLinkComponent } from './dialog-facebook-link.component';

describe('DialogFacebookLinkComponent', () => {
  let component: DialogFacebookLinkComponent;
  let fixture: ComponentFixture<DialogFacebookLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogFacebookLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogFacebookLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
