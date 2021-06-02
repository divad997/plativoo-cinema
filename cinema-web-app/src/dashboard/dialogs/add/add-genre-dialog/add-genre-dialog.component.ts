import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Genre } from 'src/app/models/genre';

@Component({
  selector: "app-add-genre-dialog",
  templateUrl: "./add-genre-dialog.component.html",
  styleUrls: ["./add-genre-dialog.component.css"],
})
export class AddGenreDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddGenreDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public newGenre: Genre
  ) {
    dialogRef.disableClose = true;
  }
}
