import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Actor } from 'src/app/models/actor';
import { ActorService } from 'src/app/services/actor.service';

@Component({
  selector: 'app-actor-tab',
  templateUrl: './actor-tab.component.html',
  styleUrls: ['./actor-tab.component.css']
})
export class ActorTabComponent implements OnInit {
  allActors: Array<Actor>;
  formattedActors: { movies: string; id: string; firstName: string; lastName: string; dateOfBirth: Date; }[];
  displayedColumns: string[] = ['fname', 'lname', 'birthday', 'movies', 'actions'];

  constructor(private actorService: ActorService, private toastrService: ToastrService) {
    this.loadAllActors();
   }

  ngOnInit(): void {
  }

  loadAllActors() {  
    this.actorService.getAllActors().subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful retrieval of actors!');
        this.allActors = res as Array<Actor>;
        this.formattedActors = this.allActors.map( a => ({
          ...a, 
          movies: a.movies.map( m => m.name).join(",")   
        })
        );
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }

  deleteActor(id: string) {
    this.actorService.deleteActor(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful deletion of list!');
        this.formattedActors = this.formattedActors.filter(a => a.id !== id);
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }
}
