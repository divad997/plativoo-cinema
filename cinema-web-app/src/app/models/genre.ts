import { Movie } from "./movie";

export class Genre {
  id: string;
  name: string;
  movies: Array<Movie> = new Array<Movie>();
}
