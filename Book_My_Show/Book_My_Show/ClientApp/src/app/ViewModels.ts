export class theatreModel {
    Id: Number;
    Name: String;
    City: String;
    NumberOfHalls: Number;
    constructor(
        Id: Number,
        Name: String,
        City: String,
        NumberOfHalls: Number
    ) {
        this.Id = Id;
        this.Name = Name;
        this.City = City;
        this.NumberOfHalls = NumberOfHalls;
    }
}

export class movieModel {
    Id: Number;
    Name: String;
    ImbdRating: Number;
    Category: String;
    Genre: String;
    ReleaseDate: String;
    ActorName: String;
    ActressName: String;
    ThemePhotoPath: String;
    constructor(
        Id: Number,
        Name: String,
        ImbdRating: Number,
        Category: String,
        Genre: String,
        ReleaseDate: String,
        ActorName: String,
        ActressName: String,
        ThemePhotoPath: String
    ) {
        this.Id = Id;
        this.Name = Name;
        this.ImbdRating = ImbdRating;
        this.Category = Category;
        this.Genre = Genre;
        this.ReleaseDate = ReleaseDate;
        this.ActorName = ActorName;
        this.ActressName = ActressName;
        this.ThemePhotoPath = ThemePhotoPath;
    }
}

export class showModel {
    Time: String;
    TheatreId: Number;
    MovieId: Number;
    constructor(
        Time: String,
        TheatreId: Number,
        MovieId: Number
    ) {
        this.Time = Time;
        this.MovieId = MovieId;
        this.TheatreId = TheatreId;
    }

}