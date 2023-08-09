import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogPractitionerComponent } from './dialog-practitioner.component';

describe('DialogPractitionerComponent', () => {
  let component: DialogPractitionerComponent;
  let fixture: ComponentFixture<DialogPractitionerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogPractitionerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogPractitionerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
