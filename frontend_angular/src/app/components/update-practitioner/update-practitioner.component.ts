import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { DataService } from 'src/app/lib/services/data.service';
import { Practitioner } from 'src/app/models/practitioner.model';
import { DialogPractitionerComponent } from '../dialog-practitioner/dialog-practitioner.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-practitioner',
  templateUrl: './update-practitioner.component.html',
  styleUrls: ['./update-practitioner.component.css'],
})
export class UpdatePractitionerComponent implements OnInit {
  practitionerForm!: FormGroup;
  id!: any;
  displayName!: any;
  discipline!: any;
  disciplines: Set<string> = new Set();

  constructor(
    private service: DataService,
    public dialog: MatDialog,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.queryParamMap.get('id');
    this.displayName = this.route.snapshot.queryParamMap.get('displayName');
    this.discipline = this.route.snapshot.queryParamMap.get('discipline');

    this.practitionerForm = new FormGroup({
      firstName: new FormControl('', []),
      lastName: new FormControl('', []),
    });
    this.service.getPractitioners().subscribe((data) => {
      for (let i = 0; i < data.length; i++) {
        this.disciplines.add(data[i].discipline);
      }
    });
    this.disciplines = new Set(this.disciplines);
  }
  updatePrtactitioner(): void {
    const dialogRef = this.dialog.open(DialogPractitionerComponent, {
      data: {
        title: 'Update behandelaar',
        displayName:
          this.practitionerForm.controls['firstName'].value +
          ' ' +
          this.practitionerForm.controls['lastName'].value,
        discipline: this.discipline,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.service.updatePractitioner(this.id, {
          displayName: result.displayName,
          discipline: result.discipline,
        });
      }
      this.location.replaceState(this.location.path());
      window.location.reload();
    });
  }
}
