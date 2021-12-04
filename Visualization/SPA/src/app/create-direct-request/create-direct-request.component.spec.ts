import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDirectRequestComponent } from './create-direct-request.component';

describe('CreateDirectRequestComponent', () => {
  let component: CreateDirectRequestComponent;
  let fixture: ComponentFixture<CreateDirectRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDirectRequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDirectRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
