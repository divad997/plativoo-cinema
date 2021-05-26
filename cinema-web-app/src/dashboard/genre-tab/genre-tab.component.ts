import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { tap } from "rxjs/internal/operators/tap";
import { filter, switchMap } from "rxjs/operators";
import { Genre } from "src/app/models/genre";
import { GenreService } from "src/app/services/genre.service";
import { AddGenreDialogComponent } from "../dialogs/add/add-genre-dialog/add-genre-dialog.component";
import { EditGenreDialogComponent } from "../dialogs/edit/edit-genre-dialog/edit-genre-dialog.component";

@Component({
  selector: "app-genre-tab",
  templateUrl: "./genre-tab.component.html",
  styleUrls: ["./genre-tab.component.css"],
})
export class GenreTabComponent implements OnInit {
  allGenres: Array<Genre>;
  displayedColumns: string[] = ["name", "movies", "actions"];
  formattedGenres: { movies: string; id: string; name: string }[];
  genre: Genre = new Genre;

  constructor(
    private genreService: GenreService,
    private toastrService: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadAllGenres();
  }

  loadAllGenres() {
    this.genreService.getAllGenres().subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful retrieval of genres!");
        this.allGenres = res as Array<Genre>;
        this.formattedGenres = this.allGenres.map((g) => ({
          ...g,
          movies: g.movies.map((m) => m.name).join(","),
        }));
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  deleteGenre(id: string) {
    this.genreService.deleteGenre(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful deletion of Genre!");
        this.formattedGenres = this.formattedGenres.filter((a) => a.id !== id);
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  startEdit(id: string) {
    this.genreService
      .getGenreById(id)
      .pipe(
        tap(
          (res: any) => {
            this.genre = res as Genre;
            this.toastrService.success(
              res.id,
              "Successful retrieval of genre!"
            );
          },
          (err) => {
            this.toastrService.error(err);
          }
        ),
        switchMap(() => {
          const dialogRef = this.dialog.open(EditGenreDialogComponent, {
            data: this.genre,
          });
          return dialogRef.afterClosed();
        }),
        //filter((result) => result === 1),
        switchMap(() => this.genreService.editGenre(this.genre))
      )
      .subscribe(
        () => {
          this.toastrService.success("Successful edit of genre!");
          this.formattedGenres = this.formattedGenres.map((d) =>
            d.id === this.genre.id ? this.formatGenre(this.genre) : d
          );

        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }

  startAdd() {
    this.dialog
      .open(AddGenreDialogComponent, {
        data: this.genre,
      })
      .afterClosed()
      .pipe(switchMap(() => this.genreService.createGenre(this.genre)))
      .subscribe(
        (res: Genre) => {
          this.toastrService.success("Successful create of genre!");
          this.formattedGenres = this.formattedGenres.concat(
            this.formatGenre(res)
          );
        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }


  formatGenre(genre: Genre) {
    return {
      ...genre,
      movies: genre.movies.map((m) => m.name).join(","),
    };
  }
}
