import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Director } from 'src/app/models/director';

@Component({
  selector: 'app-edit-director-dialog',
  templateUrl: './edit-director-dialog.component.html',
  styleUrls: ['./edit-director-dialog.component.css']
})
export class EditDirectorDialogComponent {
  constructor(public dialogRef: MatDialogRef<EditDirectorDialogComponent>, @Inject(MAT_DIALOG_DATA) public editedDirector: Director) { 
  }
}
