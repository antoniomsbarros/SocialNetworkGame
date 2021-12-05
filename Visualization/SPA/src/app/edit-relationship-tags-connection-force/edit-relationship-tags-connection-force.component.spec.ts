import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRelationshipTagsConnectionForceComponent } from './edit-relationship-tags-connection-force.component';

describe('EditRelationshipTagsConnectionForceComponent', () => {
  let component: EditRelationshipTagsConnectionForceComponent;
  let fixture: ComponentFixture<EditRelationshipTagsConnectionForceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRelationshipTagsConnectionForceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditRelationshipTagsConnectionForceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
