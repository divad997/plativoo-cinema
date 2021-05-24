import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Actor } from '../models/actor';

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  constructor(private http: HttpClient) { }

  createActor(actor: Actor) {
    return this.http.post(environment.apiUrl + '/actors/', actor);
  }

  getAllActors() {
    return this.http.get<Array<Actor>>(environment.apiUrl + '/actors/');
  }

  getActorById(id: string) {
    return this.http.get<Actor>(environment.apiUrl + '/actors/' + id);
  }

  editActor(actor: Actor) {
    return this.http.put(environment.apiUrl + "/actors/", actor);
  }

  deleteActor(id: string) {
    return this.http.delete(environment.apiUrl + '/actors/' + id);
  }
}
