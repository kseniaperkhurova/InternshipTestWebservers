import { Component, Input, OnInit } from '@angular/core';
import { Appointment } from 'src/app/models/appointment.model';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css'],
})
export class AppointmentsComponent implements OnInit {
  @Input()
  appointments: Appointment[] = [];

  ngOnInit(): void {}
}
