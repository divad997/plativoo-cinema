import { Movie } from "./movie";

export class Director {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  movies: Array<Movie> = new Array<Movie>();
}
