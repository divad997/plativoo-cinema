import { NgModule } from "@angular/core";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ActorTabComponent } from "./actor-tab/actor-tab.component";
import { DirectorTabComponent } from "./director-tab/director-tab.component";
import { GenreTabComponent } from "./genre-tab/genre-tab.component";
import { MovieTabComponent } from "./movie-tab/movie-tab.component";
import { CommonModule } from "@angular/common";
import { MatTabsModule } from "@angular/material/tabs";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatInputModule } from "@angular/material/input";
import { MatMenuModule } from "@angular/material/menu";
import { MatIconModule } from "@angular/material/icon";
import { EditDirectorDialogComponent } from "./dialogs/edit/edit-director-dialog/edit-director-dialog.component";
import { MatDialogModule } from "@angular/material/dialog";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { FormsModule } from "@angular/forms";
import { EditActorDialogComponent } from './dialogs/edit/edit-actor-dialog/edit-actor-dialog.component';
import { EditGenreDialogComponent } from './dialogs/edit/edit-genre-dialog/edit-genre-dialog.component';
import { EditMovieDialogComponent } from './dialogs/edit/edit-movie-dialog/edit-movie-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { AddDirectorDialogComponent } from './dialogs/add/add-director-dialog/add-director-dialog.component';
import { AddActorDialogComponent } from './dialogs/add/add-actor-dialog/add-actor-dialog.component';
import { AddGenreDialogComponent } from './dialogs/add/add-genre-dialog/add-genre-dialog.component';
import { AddMovieDialogComponent } from './dialogs/add/add-movie-dialog/add-movie-dialog.component';

@NgModule({
  declarations: [
    DashboardComponent,
    ActorTabComponent,
    DirectorTabComponent,
    GenreTabComponent,
    MovieTabComponent,
    EditDirectorDialogComponent,
    EditActorDialogComponent,
    EditGenreDialogComponent,
    EditMovieDialogComponent,
    AddDirectorDialogComponent,
    AddActorDialogComponent,
    AddGenreDialogComponent,
    AddMovieDialogComponent,
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatTableModule,
    MatInputModule,
    MatMenuModule,
    MatIconModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
    MatSelectModule
  ],
  exports: [DashboardComponent],
})
export class DashboardModule {}
