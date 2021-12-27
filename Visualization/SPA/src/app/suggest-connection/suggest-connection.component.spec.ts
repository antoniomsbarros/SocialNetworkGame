import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuggestConnectionComponent } from './suggest-connection.component';

describe('SuggestConnectionComponent', () => {
  let component: SuggestConnectionComponent;
  let fixture: ComponentFixture<SuggestConnectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuggestConnectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuggestConnectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
