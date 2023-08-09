import { TestBed } from '@angular/core/testing';

import { ClientAppointmentServiceService } from './client-appointment-service.service';

describe('ClientAppointmentServiceService', () => {
  let service: ClientAppointmentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientAppointmentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
