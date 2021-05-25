import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Genre } from "../models/genre";

@Injectable({
  providedIn: "root",
})
export class GenreService {
  constructor(private http: HttpClient) {}

  createGenre(genre: Genre) {
    return this.http.post(environment.apiUrl + "/genres/", genre);
  }

  getAllGenres() {
    return this.http.get<Array<Genre>>(environment.apiUrl + "/genres/");
  }

  getGenreById(id: string) {
    return this.http.get<Genre>(environment.apiUrl + "/genres/" + id);
  }

  editGenre(genre: Genre) {
    return this.http.put(environment.apiUrl + "/genres/", genre);
  }

  deleteGenre(id: string) {
    return this.http.delete(environment.apiUrl + "/genres/" + id);
  }
}
