import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Actor } from 'src/app/models/actor';

@Component({
  selector: 'app-edit-actor-dialog',
  templateUrl: './edit-actor-dialog.component.html',
  styleUrls: ['./edit-actor-dialog.component.css']
})
export class EditActorDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<EditActorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public editedActor: Actor
  ) {}
}
