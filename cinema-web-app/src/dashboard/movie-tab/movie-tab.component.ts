import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Actor } from 'src/app/models/actor';
import { Director } from 'src/app/models/director';
import { Genre } from 'src/app/models/genre';
import { Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie-tab',
  templateUrl: './movie-tab.component.html',
  styleUrls: ['./movie-tab.component.css']
})
export class MovieTabComponent implements OnInit {
  allMovies: Array<Movie>;
  displayedColumns: string[] = ['name', 'released', 'director', 'genre', 'actors', 'actions'];
  formattedMovies: { actors: string; director: string; id: string; name: string; releaseDate: Date; genreId: string; genre: Genre; directorId: string; }[];


  constructor(private movieService: MovieService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.loadAllMovies();
  }

  loadAllMovies() {  
    this.movieService.getAllMovies().subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful retrieval of movies!');
        this.allMovies = res as Array<Movie>;
        this.formattedMovies = this.allMovies.map( m => ({
          ...m, 
          actors: m.actors.map( a => a.firstName + ' ' + a.lastName).join(", "),   
          director: m.director.firstName + ' ' + m.director.lastName
        })
        );
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }

  deleteMovie(id: string) {
    this.movieService.deleteMovie(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful deletion of list!');
        this.formattedMovies = this.formattedMovies.filter(a => a.id !== id);
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }
}
