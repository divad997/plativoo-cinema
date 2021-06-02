export class MovieDto {
    id: string;
    name: string;
    releaseDate: Date;
    genreId: string;
    directorId: string;
    actorIds: Array<string> = new Array<string>();
  }
  