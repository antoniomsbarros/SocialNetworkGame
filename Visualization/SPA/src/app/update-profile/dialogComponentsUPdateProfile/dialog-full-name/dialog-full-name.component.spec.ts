import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogFullNameComponent } from './dialog-full-name.component';

describe('DialogFullNameComponent', () => {
  let component: DialogFullNameComponent;
  let fixture: ComponentFixture<DialogFullNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogFullNameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogFullNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
