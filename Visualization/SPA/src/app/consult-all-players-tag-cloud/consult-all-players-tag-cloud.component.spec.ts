import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultAllPlayersTagCloudComponent } from './consult-all-players-tag-cloud.component';

describe('ConsultAllPlayersTagCloudComponent', () => {
  let component: ConsultAllPlayersTagCloudComponent;
  let fixture: ComponentFixture<ConsultAllPlayersTagCloudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultAllPlayersTagCloudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultAllPlayersTagCloudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
