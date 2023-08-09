import { Component, Inject } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogPractitioner } from 'src/app/lib/interfaces/dialogPractitioner';

@Component({
  selector: 'app-dialog-practitioner',
  templateUrl: './dialog-practitioner.component.html',
  styleUrls: ['./dialog-practitioner.component.css'],
})
export class DialogPractitionerComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogPractitionerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogPractitioner
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
