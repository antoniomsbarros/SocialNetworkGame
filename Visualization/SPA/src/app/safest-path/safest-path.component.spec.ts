import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SafestPathComponent } from './safest-path.component';

describe('SafestPathComponent', () => {
  let component: SafestPathComponent;
  let fixture: ComponentFixture<SafestPathComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SafestPathComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SafestPathComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
