import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogLinkedinLinkComponent } from './dialog-linkedin-link.component';

describe('DialogLinkedinLinkComponent', () => {
  let component: DialogLinkedinLinkComponent;
  let fixture: ComponentFixture<DialogLinkedinLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogLinkedinLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogLinkedinLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
