import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletePractitionerComponent } from './delete-practitioner.component';

describe('DeletePractitionerComponent', () => {
  let component: DeletePractitionerComponent;
  let fixture: ComponentFixture<DeletePractitionerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletePractitionerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeletePractitionerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
