import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailSignFORMComponent } from './email-sign-form.component';

describe('EmailSignFORMComponent', () => {
  let component: EmailSignFORMComponent;
  let fixture: ComponentFixture<EmailSignFORMComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EmailSignFORMComponent]
    });
    fixture = TestBed.createComponent(EmailSignFORMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
