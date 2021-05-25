import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Genre } from 'src/app/models/genre';

@Component({
  selector: 'app-edit-genre-dialog',
  templateUrl: './edit-genre-dialog.component.html',
  styleUrls: ['./edit-genre-dialog.component.css']
})
export class EditGenreDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<EditGenreDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public editedGenre: Genre
  ) {}
}
