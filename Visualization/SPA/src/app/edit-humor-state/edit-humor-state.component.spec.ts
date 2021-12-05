import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditHumorStateComponent } from './edit-humor-state.component';

describe('EditHumorStateComponent', () => {
  let component: EditHumorStateComponent;
  let fixture: ComponentFixture<EditHumorStateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditHumorStateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditHumorStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
