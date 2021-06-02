import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Actor } from "src/app/models/actor";
import { Director } from "src/app/models/director";
import { Genre } from "src/app/models/genre";
import { Movie } from "src/app/models/movie";

@Component({
  selector: "app-edit-movie-dialog",
  templateUrl: "./edit-movie-dialog.component.html",
  styleUrls: ["./edit-movie-dialog.component.css"],
})
export class EditMovieDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<EditMovieDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      editedMovie: Movie;
      actors: Array<Actor>;
      directors: Array<Director>;
      genres: Array<Genre>;
    }
  ) {}
  compareActors(a1: Actor, a2: Actor) {
    if (a1.id == a2.id) return true;
    else return false;
  }
  compareGenres(g1: Genre, g2: Genre) {
    if (g1.id == g2.id) return true;
    else return false;
  }
  compareDirectors(d1: Director, d2: Director) {
    if (d1.id == d2.id) return true;
    else return false;
  }
}
