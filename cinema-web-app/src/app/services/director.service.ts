import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Director } from '../models/director';

@Injectable({
  providedIn: 'root'
})
export class DirectorService {

  constructor(private http: HttpClient) { }

  createDirector(director: Director) {
    return this.http.post(environment.apiUrl + '/directors/', director);
  }

  getAllDirectors() {
    return this.http.get<Array<Director>>(environment.apiUrl + '/directors/');
  }

  getDirectorById(id: string) {
    return this.http.get<Director>(environment.apiUrl + '/directors/' + id);
  }

  editDirector(director: Director) {
    return this.http.put(environment.apiUrl + "/directors/", director);
  }

  deleteDirector(id: string) {
    return this.http.delete(environment.apiUrl + '/directors/' + id);
  }
}
