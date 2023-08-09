import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { FillInComponent } from './components/fill-in/fill-in.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { AppointmentsComponent } from './components/appointments/appointments.component';
import { AddPractitionerComponent } from './components/add-practitioner/add-practitioner.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { PractitionersComponent } from './components/practitioners/practitioners.component';

import { NavbarComponent } from './components/navbar/navbar.component';
import { UpdatePractitionerComponent } from './components/update-practitioner/update-practitioner.component';
import { DeletePractitionerComponent } from './components/delete-practitioner/delete-practitioner.component';
import { DialogPractitionerComponent } from './components/dialog-practitioner/dialog-practitioner.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    FillInComponent,
    AppointmentsComponent,
    AddPractitionerComponent,
    PractitionersComponent,

    NavbarComponent,
    UpdatePractitionerComponent,
    DeletePractitionerComponent,
    DialogPractitionerComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
