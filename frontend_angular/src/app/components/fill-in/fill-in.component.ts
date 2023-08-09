import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { Appointment } from 'src/app/models/appointment.model';
import { Client } from 'src/app/models/client.model';
import { Practitioner } from 'src/app/models/practitioner.model';
import { ClientAppointmentServiceService } from 'src/app/services/client-appointment-service.service';
import { PractitionerAppointmentServiceService } from 'src/app/services/practitioner-appointment-service.service';

@Component({
  selector: 'app-fill-in',
  templateUrl: './fill-in.component.html',
  styleUrls: ['./fill-in.component.css'],
})
export class FillInComponent implements OnInit {
  selectedGroup = '';
  selectedName = '';
  startDate = '';
  endDate = '';
  practitioners: Practitioner[] = [];
  clients: Client[] = [];
  selectedClient!: Client;
  selectedPractitioner!: Practitioner;
  getAppointments: Appointment[] = [];

  constructor(
    private clientService: ClientAppointmentServiceService,
    private practitionerService: PractitionerAppointmentServiceService,
    private router: Router
  ) {}

  onStartDate(event: any): void {
    const date = new Date(event);
    this.startDate = this.formattedStringToDate(date);
  }
  onEndDate(event: any): void {
    const date = new Date(event);
    this.endDate = this.formattedStringToDate(date);
  }
  formattedStringToDate(date: any) {
    const formattedDate = moment(date).format('YYYY-MM-DD');
    return formattedDate;
  }
  getAppoinments(): void {
    if (this.selectedGroup == 'client') {
      console.log(this.selectedClient.displayName + 'is een name');
      this.clientService
        .getAllClientsAppointmentsForTimeRange(
          this.selectedClient.id,
          this.startDate,
          this.endDate
        )
        .subscribe((data) => {
          this.getAppointments = data;
        });
    } else if (this.selectedGroup == 'practitioner') {
      this.practitionerService
        .getAllPractitionersAppointmentsForTimeRange(
          this.selectedPractitioner.id,
          this.startDate,
          this.endDate
        )
        .subscribe((data) => {
          this.getAppointments = data;
        });
    }
  }
  ngOnInit(): void {
    this.clientService.getAllClients().subscribe((data) => {
      this.clients = data;
    });
    console.log(this.clients.length);
    this.practitionerService.getAllPractitioners().subscribe((data) => {
      this.practitioners = data;
    });
  }
  onChangeClient(): void {}
  addPractioner() {
    console.log('hello i am here');
    this.router.navigate(['/addPractitioner']);
  }
}
