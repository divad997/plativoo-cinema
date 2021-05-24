import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ActorTabComponent } from './actor-tab/actor-tab.component';
import { DirectorTabComponent } from './director-tab/director-tab.component';
import { GenreTabComponent } from './genre-tab/genre-tab.component';
import { MovieTabComponent } from './movie-tab/movie-tab.component';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { EditDirectorDialogComponent } from './dialogs/edit/edit-director-dialog/edit-director-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [DashboardComponent, ActorTabComponent, DirectorTabComponent, GenreTabComponent, MovieTabComponent, EditDirectorDialogComponent],
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
    MatNativeDateModule
  ],
  exports: [
    DashboardComponent,
  ]
})
export class DashboardModule { }
