import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagCloudRelationshipsComponent } from './tag-cloud-relationships.component';

describe('TagCloudRelationshipsComponent', () => {
  let component: TagCloudRelationshipsComponent;
  let fixture: ComponentFixture<TagCloudRelationshipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TagCloudRelationshipsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TagCloudRelationshipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
