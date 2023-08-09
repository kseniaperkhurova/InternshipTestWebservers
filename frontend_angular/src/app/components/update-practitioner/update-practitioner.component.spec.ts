import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePractitionerComponent } from './update-practitioner.component';

describe('UpdatePractitionerComponent', () => {
  let component: UpdatePractitionerComponent;
  let fixture: ComponentFixture<UpdatePractitionerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePractitionerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatePractitionerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
