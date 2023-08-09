import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { AppointmentRequest } from '../models/appointmentRequest.model';
import { Practitioner } from '../models/practitioner.model';

@Injectable({
  providedIn: 'root',
})
export class PractitionerAppointmentServiceService {
  practitionerUrl = 'http://localhost:33893/api/Practitioners/';
  appointmentPractitionerUrl =
    'http://localhost:33893/api/Appointments/practitioner';
  constructor(private httpClient: HttpClient) {}

  getAllPractitioners(): Observable<Practitioner[]> {
    return this.httpClient.get<Practitioner[]>(this.practitionerUrl);
  }

  getAllPractitionersAppointmentsForTimeRange(
    id: any,
    startDate: any,
    endDate: any
  ): Observable<Appointment[]> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append('id', id);
    queryParams = queryParams.append('startDate', startDate);
    queryParams = queryParams.append('endDate', endDate);
    return this.httpClient.get<Appointment[]>(this.appointmentPractitionerUrl, {
      params: queryParams,
    });
  }
}
