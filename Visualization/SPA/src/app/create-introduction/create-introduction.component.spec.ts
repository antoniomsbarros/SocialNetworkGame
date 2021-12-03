import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateIntroductionComponent } from './create-introduction.component';

describe('CreateIntroductionComponent', () => {
  let component: CreateIntroductionComponent;
  let fixture: ComponentFixture<CreateIntroductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateIntroductionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateIntroductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
