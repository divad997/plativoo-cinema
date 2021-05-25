import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Actor } from 'src/app/models/actor';

@Component({
  selector: 'app-add-actor-dialog',
  templateUrl: './add-actor-dialog.component.html',
  styleUrls: ['./add-actor-dialog.component.css'],
})
export class AddActorDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddActorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public newActor: Actor
  ) {}
}
