import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultAllRelationshipsTagCloudComponent } from './consult-all-relationships-tag-cloud.component';

describe('ConsultAllRelationshipsTagCloudComponent', () => {
  let component: ConsultAllRelationshipsTagCloudComponent;
  let fixture: ComponentFixture<ConsultAllRelationshipsTagCloudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultAllRelationshipsTagCloudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultAllRelationshipsTagCloudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
