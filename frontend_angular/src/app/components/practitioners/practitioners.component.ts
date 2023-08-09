import { Component, Input, OnInit } from '@angular/core';
import { Disciplines } from 'src/app/lib/enum/disciplines';
import { Practitioners } from 'src/app/lib/interfaces/practitioners';
import { DataService } from 'src/app/lib/services/data.service';
import { MatDialog } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { DialogPractitionerComponent } from '../dialog-practitioner/dialog-practitioner.component';

@Component({
  selector: 'app-practitioners',
  templateUrl: './practitioners.component.html',
  styleUrls: ['./practitioners.component.css'],
})
export class PractitionersComponent implements OnInit {
  disciplines = Object.values(Disciplines);
  practitioners: Practitioners[] = [];

  constructor(
    public dataService: DataService,
    public dialog: MatDialog,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.dataService.getPractitioners().subscribe((data) => {
      this.practitioners = data;
    });
  }
  delete(id: string, displayName: string, discipline: string): void {
    const dialogRef = this.dialog.open(DialogPractitionerComponent, {
      data: {
        title: 'Wilt u zeker deze behandelaar verwijderen',
        displayName: displayName,
        discipline: discipline,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.dataService.deletePractirioner(id);
      }
      this.location.replaceState(this.location.path());
      window.location.reload();
    });
  }
}
