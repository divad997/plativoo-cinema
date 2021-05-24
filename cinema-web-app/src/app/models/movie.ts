import { Actor } from "./actor";
import { Director } from "./director";
import { Genre } from "./genre";

export class Movie {
    id: string;
    name: string;
    releaseDate: Date;
    genreId: string;
    genre: Genre;
    directorId: string;
    director: Director;
    actors: Array<Actor> = new Array<Actor>();
}
