import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogShortNameComponent } from './dialog-short-name.component';

describe('DialogShortNameComponent', () => {
  let component: DialogShortNameComponent;
  let fixture: ComponentFixture<DialogShortNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogShortNameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogShortNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
