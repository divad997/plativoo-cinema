import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Director } from 'src/app/models/director';

@Component({
  selector: 'app-add-director-dialog',
  templateUrl: './add-director-dialog.component.html',
  styleUrls: ['./add-director-dialog.component.css'],
})
export class AddDirectorDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddDirectorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public newDirector: Director
  ) {}
}
