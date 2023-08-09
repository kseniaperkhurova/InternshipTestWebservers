import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, Observable, tap } from 'rxjs';
import { Client } from '../models/client.model';
import { Appointment } from '../models/appointment.model';
import { AppointmentRequest } from '../models/appointmentRequest.model';

@Injectable({
  providedIn: 'root',
})
export class ClientAppointmentServiceService {
  clientUrl = 'http://localhost:33893/api/Clients/';
  appointmentClientUrl = 'http://localhost:33893/api/Appointments/client';
  httpParam!: HttpParams;
  constructor(private httpClient: HttpClient) {}

  getAllClients(): Observable<Client[]> {
    return this.httpClient.get<Client[]>(this.clientUrl);
  }

  getAllClientsAppointmentsForTimeRange(
    id: any,
    startDate: any,
    endDate: any
  ): Observable<Appointment[]> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append('id', id);
    queryParams = queryParams.append('startDate', startDate);
    queryParams = queryParams.append('endDate', endDate);
    return this.httpClient.get<Appointment[]>(this.appointmentClientUrl, {
      params: queryParams,
    });
  }
}
