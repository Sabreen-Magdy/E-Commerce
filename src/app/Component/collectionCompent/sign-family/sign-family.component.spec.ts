import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignFamilyComponent } from './sign-family.component';

describe('SignFamilyComponent', () => {
  let component: SignFamilyComponent;
  let fixture: ComponentFixture<SignFamilyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SignFamilyComponent]
    });
    fixture = TestBed.createComponent(SignFamilyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
