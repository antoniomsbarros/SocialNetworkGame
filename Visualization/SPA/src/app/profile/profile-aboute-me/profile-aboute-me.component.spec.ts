import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileAbouteMeComponent } from './profile-aboute-me.component';

describe('ProfileAbouteMeComponent', () => {
  let component: ProfileAbouteMeComponent;
  let fixture: ComponentFixture<ProfileAbouteMeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileAbouteMeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileAbouteMeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
