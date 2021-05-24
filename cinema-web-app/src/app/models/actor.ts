import { Movie } from "./movie";

export class Actor {
    id: string;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    movies: Array<Movie> = new Array<Movie>();
}
