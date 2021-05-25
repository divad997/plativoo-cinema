import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { forkJoin } from "rxjs";
import { switchMap, tap } from "rxjs/operators";
import { Actor } from "src/app/models/actor";
import { Director } from "src/app/models/director";
import { Genre } from "src/app/models/genre";
import { Movie } from "src/app/models/movie";
import { ActorService } from "src/app/services/actor.service";
import { DirectorService } from "src/app/services/director.service";
import { GenreService } from "src/app/services/genre.service";
import { MovieService } from "src/app/services/movie.service";
import { EditMovieDialogComponent } from "../dialogs/edit/edit-movie-dialog/edit-movie-dialog.component";

@Component({
  selector: "app-movie-tab",
  templateUrl: "./movie-tab.component.html",
  styleUrls: ["./movie-tab.component.css"],
})
export class MovieTabComponent implements OnInit {
  allMovies: Array<Movie>;
  allActors: Array<Actor>;
  allDirectors: Array<Director>;
  allGenres: Array<Genre>;
  displayedColumns: string[] = [
    "name",
    "released",
    "director",
    "genre",
    "actors",
    "actions",
  ];
  formattedMovies: {
    actors: string;
    director: string;
    id: string;
    name: string;
    releaseDate: Date;
    genreId: string;
    genre: Genre;
    directorId: string;
  }[];
  editedMovie: Movie;
  editedActors: Array<Actor>;
  editedDirector: Director;
  editedGenre: Genre;
  movie: Movie;

  constructor(
    private movieService: MovieService,
    private actorService: ActorService,
    private directorService: DirectorService,
    private genreService: GenreService,
    private toastrService: ToastrService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadAllMovies();
    this.loadOtherModels();
  }

  loadAllMovies() {
    this.movieService.getAllMovies().subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful retrieval of movies!");
        this.allMovies = res as Array<Movie>;
        this.formattedMovies = this.allMovies.map(this.formatMovie)
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  loadOtherModels() {
    forkJoin({
      requestOne: this.actorService.getAllActors(),
      requestTwo: this.directorService.getAllDirectors(),
      requestThree: this.genreService.getAllGenres(),
    }).subscribe(
      ({ requestOne, requestTwo, requestThree }) => {
        this.allActors = requestOne;
        this.allDirectors = requestTwo;
        this.allGenres = requestThree;
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  deleteMovie(id: string) {
    this.movieService.deleteMovie(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful deletion of movie!");
        this.formattedMovies = this.formattedMovies.filter((a) => a.id !== id);
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  startEdit(id: string) {
    this.movieService
      .getMovieById(id)
      .pipe(
        tap(
          (res: any) => {
            this.editedMovie = res as Movie;
            this.editedDirector = this.editedMovie.director;
            this.editedGenre = this.editedMovie.genre;
            this.editedActors = this.editedMovie.actors;
            this.toastrService.success(
              res.id,
              "Successful retrieval of movie!"
            );
          },
          (err) => {
            this.toastrService.error(err);
          }
        ),
        switchMap(() => {
          const dialogRef = this.dialog.open(EditMovieDialogComponent, {
            data: { 
              editedMovie : this.editedMovie,
              actors: this.allActors,
              directors: this.allDirectors,
              genres: this.allGenres,
              editedActors: this.editedActors,
              editedDirector: this.editedDirector,
              editedGenre: this.editedGenre
             }, 
          });
          return dialogRef.afterClosed();
        }),
        //filter((result) => result === 1),
        switchMap(() => this.movieService.editMovie(this.editedMovie))
      )
      .subscribe(
        () => {
          this.toastrService.success("Successful edit of movie!");
          this.formattedMovies = this.formattedMovies.map((d) =>
            d.id === this.movie.id ? this.formatMovie(this.movie) : d
          );
        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }

  formatMovie(movie: Movie) {
    return {
      ...movie,
          actors: movie.actors
            .map((a) => a.firstName + " " + a.lastName)
            .join(", "),
          director: movie.director.firstName + " " + movie.director.lastName,
    };
  }
}
