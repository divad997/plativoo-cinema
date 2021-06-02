import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Movie } from "../models/movie";
import { MovieDto } from "../models/movie-dto";

@Injectable({
  providedIn: "root",
})
export class MovieService {
  constructor(private http: HttpClient) {}

  mapDto(movie: Movie) : MovieDto {
    var movieDto = new MovieDto();
    movieDto.id = movie.id;
    movieDto.name = movie.name;
    movieDto.releaseDate = movie.releaseDate;
    movieDto.directorId = movie.director.id;
    movieDto.genreId = movie.genre.id;
    movie.actors.forEach((actor) => movieDto.actorIds.push(actor.id));
    return movieDto;
  }

  createMovie(movie: MovieDto) {
    return this.http.post(environment.apiUrl + "/movies/", movie);
  }

  getAllMovies() {
    return this.http.get<Array<Movie>>(environment.apiUrl + "/movies/");
  }

  getMovieById(id: string) {
    return this.http.get<Movie>(environment.apiUrl + "/movies/" + id);
  }

  editMovie(movie: MovieDto) {
    return this.http.put(environment.apiUrl + "/movies/", movie);
  }

  deleteMovie(id: string) {
    return this.http.delete(environment.apiUrl + "/movies/" + id);
  }
}
