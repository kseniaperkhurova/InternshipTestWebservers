import { TestBed } from '@angular/core/testing';

import { PractitionerAppointmentServiceService } from './practitioner-appointment-service.service';

describe('PractitionerAppointmentServiceService', () => {
  let service: PractitionerAppointmentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PractitionerAppointmentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
