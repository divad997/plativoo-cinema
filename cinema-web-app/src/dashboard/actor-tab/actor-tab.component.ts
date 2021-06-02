import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Actor } from "src/app/models/actor";
import { ActorService } from "src/app/services/actor.service";
import { MatDialog } from "@angular/material/dialog";
import { switchMap, tap } from "rxjs/operators";
import { EditActorDialogComponent } from "../dialogs/edit/edit-actor-dialog/edit-actor-dialog.component";
import { AddActorDialogComponent } from "../dialogs/add/add-actor-dialog/add-actor-dialog.component";

@Component({
  selector: "app-actor-tab",
  templateUrl: "./actor-tab.component.html",
  styleUrls: ["./actor-tab.component.css"],
})
export class ActorTabComponent implements OnInit {
  allActors: Array<Actor>;
  formattedActors: {
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
  actor: Actor = new Actor();

  constructor(
    private actorService: ActorService,
    private toastrService: ToastrService,
    public dialog: MatDialog
  ) {
    this.loadAllActors();
  }

  ngOnInit(): void {}

  loadAllActors() {
    this.actorService.getAllActors().subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful retrieval of actors!");
        this.allActors = res as Array<Actor>;
        this.formattedActors = this.allActors.map(this.formatActor);
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  deleteActor(id: string) {
    this.actorService.deleteActor(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, "Successful deletion of actor!");
        this.formattedActors = this.formattedActors.filter((a) => a.id !== id);
        this.actor = new Actor();
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  startEdit(id: string) {
    this.actorService
      .getActorById(id)
      .pipe(
        tap(
          (res: any) => {
            this.actor = res as Actor;
            this.toastrService.success(
              res.id,
              "Successful retrieval of actor!"
            );
          },
          (err) => {
            this.toastrService.error(err);
          }
        ),
        switchMap(() => {
          const dialogRef = this.dialog.open(EditActorDialogComponent, {
            data: this.actor,
          });
          return dialogRef.afterClosed();
        }),
        //filter((result) => result === 1),
        switchMap(() => this.actorService.editActor(this.actor))
      )
      .subscribe(
        () => {
          this.toastrService.success("Successful edit of actor!");
          this.formattedActors = this.formattedActors.map((d) =>
            d.id === this.actor.id ? this.formatActor(this.actor) : d
          );
        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }

  startAdd() {
    this.dialog
      .open(AddActorDialogComponent, {
        data: this.actor,
      })
      .afterClosed()
      .pipe(switchMap(() => this.actorService.createActor(this.actor)))
      .subscribe(
        (res: Actor) => {
          this.toastrService.success("Successful create of actor!");
          this.formattedActors = this.formattedActors.concat(
            this.formatActor(res)
          );
        },
        (err) => {
          this.toastrService.error(err);
        }
      );
  }

  formatActor(actor: Actor) {
    return {
      ...actor,
      movies: actor.movies.map((m) => m.name).join(","),
    };
  }
}
