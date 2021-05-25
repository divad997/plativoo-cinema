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
      editedActors: Array<Actor>;
      editedDirector: Director;
      editedGenre: Genre;
    }
  ) {}
  compareActors(a1: Actor, a2: Actor) {
    if (a1.id == a2.id) return true;
    else return false;
  }
}
