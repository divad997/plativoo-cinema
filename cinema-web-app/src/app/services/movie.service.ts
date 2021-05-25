import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Movie } from "../models/movie";

@Injectable({
  providedIn: "root",
})
export class MovieService {
  constructor(private http: HttpClient) {}

  createMovie(movie: Movie) {
    return this.http.post(environment.apiUrl + "/movies/", movie);
  }

  getAllMovies() {
    return this.http.get<Array<Movie>>(environment.apiUrl + "/movies/");
  }

  getMovieById(id: string) {
    return this.http.get<Movie>(environment.apiUrl + "/movies/" + id);
  }

  editMovie(movie: Movie) {
    return this.http.put(environment.apiUrl + "/movies/", movie);
  }

  deleteMovie(id: string) {
    return this.http.delete(environment.apiUrl + "/movies/" + id);
  }
}
