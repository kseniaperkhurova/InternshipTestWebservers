import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Appointment } from '../interfaces/appointment';
import { PractionerRequest } from '../interfaces/practitionerRequest';
import { Practitioner } from 'src/app/models/practitioner.model';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public setPractitioner$ = new BehaviorSubject<any>(null);
  public getPractitioner$ = this.setPractitioner$.asObservable();
  username: string = '';
  selectedName: string = '';
  selectedDiscipline: string = '';
  selectedId: string = '';

  constructor(private http: HttpClient) {}

  public getPractitioners(): Observable<any> {
    return this.http.get('http://localhost:33893/api/Practitioners/');
  }
  public getClients(): Observable<any> {
    return this.http.get('http://localhost:33893/api/Clients');
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
    return this.http.get<Appointment[]>(
      'http://localhost:33893/api/Appointments/client',
      {
        params: queryParams,
      }
    );
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
    return this.http.get<Appointment[]>(
      'http://localhost:33893/api/Appointments/practitioner',
      {
        params: queryParams,
      }
    );
  }
  postPractirioner(practionerRequest: PractionerRequest): any {
    const headers = { 'Content-Type': 'application/json' };
    this.http
      .post<any>(
        'http://localhost:33893/api/Practitioners/',
        practionerRequest,
        { headers }
      )
      .subscribe((response) => {
        console.log(response);
      });
  }
  deletePractirioner(practionerId: any): any {
    let queryParams = new HttpParams();
    queryParams = queryParams.append('id', practionerId);
    this.http
      .delete<any>('http://localhost:33893/api/Practitioners/', {
        params: queryParams,
      })
      .subscribe((response) => {
        console.log(response);
      });
  }
  updatePractitioner(id: any, practitioner: PractionerRequest): any {
    const headers = { 'Content-Type': 'application/json' };
    let queryParams = new HttpParams();
    queryParams = queryParams.append('id', id);
    this.http
      .put<any>('http://localhost:33893/api/Practitioners/', {
        params: queryParams,
        practitioner,
        headers,
      })
      .subscribe((response) => {
        console.log(response);
      });
  }
}
