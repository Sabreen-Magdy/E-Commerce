import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoWayBindingWithFormsModuleComponent } from './two-way-binding-with-forms-module.component';

describe('TwoWayBindingWithFormsModuleComponent', () => {
  let component: TwoWayBindingWithFormsModuleComponent;
  let fixture: ComponentFixture<TwoWayBindingWithFormsModuleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TwoWayBindingWithFormsModuleComponent]
    });
    fixture = TestBed.createComponent(TwoWayBindingWithFormsModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
