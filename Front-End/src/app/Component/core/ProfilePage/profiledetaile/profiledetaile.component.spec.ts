import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfiledetaileComponent } from './profiledetaile.component';

describe('ProfiledetaileComponent', () => {
  let component: ProfiledetaileComponent;
  let fixture: ComponentFixture<ProfiledetaileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProfiledetaileComponent]
    });
    fixture = TestBed.createComponent(ProfiledetaileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
