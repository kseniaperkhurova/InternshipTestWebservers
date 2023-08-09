import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { DataService } from 'src/app/lib/services/data.service';
import { Practitioner } from 'src/app/models/practitioner.model';
import { DialogPractitionerComponent } from '../dialog-practitioner/dialog-practitioner.component';

@Component({
  selector: 'app-add-practitioner',
  templateUrl: './add-practitioner.component.html',
  styleUrls: ['./add-practitioner.component.css'],
})
export class AddPractitionerComponent implements OnInit {
  practitionerForm!: FormGroup;
  add!: boolean;
  selectedDiscipline!: '';
  disciplines: Set<string> = new Set();
  practitioners: Practitioner[] = [];

  constructor(
    private service: DataService,
    public dialog: MatDialog,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.practitionerForm = new FormGroup({
      firstName: new FormControl('', []),
      lastName: new FormControl('', []),
    });
    this.service.getPractitioners().subscribe((data) => {
      this.practitioners = data;
      for (let i = 0; i < data.length; i++) {
        this.disciplines.add(data[i].discipline);
      }
    });
    this.disciplines = new Set(this.disciplines);
  }
  addPrtactitioner(): void {
    const dialogRef = this.dialog.open(DialogPractitionerComponent, {
      data: {
        title: 'Voeg nieuwe behandelaar toe',
        displayName:
          this.practitionerForm.controls['firstName'].value +
          ' ' +
          this.practitionerForm.controls['lastName'].value,
        discipline: this.selectedDiscipline,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.service.postPractirioner({
          displayName: result.displayName,
          discipline: result.discipline,
        });
      }
      this.location.replaceState(this.location.path());
      window.location.reload();
    });
  }
}
