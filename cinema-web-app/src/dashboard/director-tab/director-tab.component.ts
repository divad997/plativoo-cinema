import { Component, Inject, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Director } from 'src/app/models/director';
import { DirectorService } from 'src/app/services/director.service';
import { EditDirectorDialogComponent } from '../dialogs/edit/edit-director-dialog/edit-director-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { switchMap, tap, filter } from 'rxjs/operators';

@Component({
  selector: "app-director-tab",
  templateUrl: "./director-tab.component.html",
  styleUrls: ["./director-tab.component.css"],
})
export class DirectorTabComponent implements OnInit {
  director: Director;
  allDirectors: Array<Director>;
  formattedDirector: {
    movies: string;
    id: string;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
  };
  formattedDirectors: {
    movies: string;
    id: string;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
  }[];
  displayedColumns: string[] = [
    "fname",
    "lname",
    "birthday",
    "movies",
    "actions",
  ];

  constructor(
    private directorService: DirectorService,
    private toastrService: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadAllDirectors();
  }

  loadAllDirectors() {
    this.directorService.getAllDirectors().subscribe(
      (res) => {
        this.toastrService.success("Successful retrieval of directors!");
        console.log(res);
        this.allDirectors = res;
        this.formattedDirectors = this.allDirectors.map((d) => ({
          ...d,
          movies: d.movies.map((m) => m.name).join(","),
        }));
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  deleteDirector(id: string) {
    this.directorService.deleteDirector(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful deletion of director!");
        this.formattedDirectors = this.formattedDirectors.filter(
          (a) => a.id !== id
        );
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  startEdit(id: string) {
    this.directorService
      .getDirectorById(id)
      .pipe(
        tap(
          (res: any) => {
            this.director = res as Director;
            this.toastrService.success(
              res.id,
              "Successful retrieval of director!"
            );
          },
          (err) => {
            this.toastrService.error(err);
          }
        ),
        switchMap(() => {
          const dialogRef = this.dialog.open(EditDirectorDialogComponent, {
            data: this.director,
          });
          return dialogRef.afterClosed();
        }),
        //filter((result) => result === 1),
        switchMap(() => this.directorService.editDirector(this.director))
      )
      .subscribe(
        () => {
          this.toastrService.success("Successful edit of director!");
        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }
}
