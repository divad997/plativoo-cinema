import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Genre } from 'src/app/models/genre';
import { GenreService } from 'src/app/services/genre.service';

@Component({
  selector: 'app-genre-tab',
  templateUrl: './genre-tab.component.html',
  styleUrls: ['./genre-tab.component.css']
})
export class GenreTabComponent implements OnInit {
  allGenres: Array<Genre>;
  displayedColumns: string[] = ['name', 'movies', 'actions'];
  formattedGenres: { movies: string; id: string; name: string; }[];

  constructor(private genreService: GenreService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.loadAllGenres();
  }

  loadAllGenres() {  
    this.genreService.getAllGenres().subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful retrieval of genres!');
        this.allGenres = res as Array<Genre>;
        this.formattedGenres = this.allGenres.map( g => ({
          ...g, 
          movies: g.movies.map( m => m.name).join(",")   
        })
        );
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }

  deleteGenre(id: string) {
    this.genreService.deleteGenre(id).subscribe(
      (res: any) => {
        this.toastrService.success(res, 'Successful deletion of Genre!');
        this.formattedGenres = this.formattedGenres.filter(a => a.id !== id);
      },
      err => {
        this.toastrService.error(err);
      }
    );
  }
}
