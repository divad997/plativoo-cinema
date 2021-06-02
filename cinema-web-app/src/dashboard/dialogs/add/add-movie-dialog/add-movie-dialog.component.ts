import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Actor } from 'src/app/models/actor';
import { Director } from 'src/app/models/director';
import { Genre } from 'src/app/models/genre';
import { Movie } from 'src/app/models/movie';
import { EditMovieDialogComponent } from '../../edit/edit-movie-dialog/edit-movie-dialog.component';

@Component({
  selector: "app-add-movie-dialog",
  templateUrl: "./add-movie-dialog.component.html",
  styleUrls: ["./add-movie-dialog.component.css"],
})
export class AddMovieDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<EditMovieDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      movie: Movie;
      actors: Array<Actor>;
      directors: Array<Director>;
      genres: Array<Genre>;
    }
  ) {
    dialogRef.disableClose = true;
  }
}
