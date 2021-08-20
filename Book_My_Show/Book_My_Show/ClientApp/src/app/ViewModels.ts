import { User } from "oidc-client";

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

export class showTheatreModel {
    Time: String;
    TheatreId: Number;
    MovieId: Number;
    Name: String;
    constructor(
        Time: String,
        TheatreId: Number,
        MovieId: Number,
        Name: String
    ) {
        this.Time = Time;
        this.MovieId = MovieId;
        this.TheatreId = TheatreId;
        this.Name = Name;
    }
}

export class showMovieModel {
    Time: String;
    TheatreId: Number;
    MovieId: Number;
    Name: String;
    ImbdRating: Number;
    Category: String;
    Genre: String;
    ReleaseDate: String;
    ActorName: String;
    ActressName: String;
    ThemePhotoPath: String;
    constructor(
        Time: String,
        TheatreId: Number,
        MovieId: Number,
        Name: String,
        ImbdRating: Number,
        Category: String,
        Genre: String,
        ReleaseDate: String,
        ActorName: String,
        ActressName: String,
        ThemePhotoPath: String
    ) {
        this.Time = Time;
        this.MovieId = MovieId;
        this.TheatreId = TheatreId;
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

export class SeatModel {
    Number: Number;
    ShowTime : String;
    TheatreId: Number;
    MovieId : Number;
    Availability: String;
    constructor(
        Number: Number,
        ShowTime : String,
        TheatreId: Number,
        MovieId : Number,
        Availability: String
    ) {
        this.Number = Number;
        this.ShowTime = ShowTime;
        this.TheatreId = TheatreId;
        this.MovieId = MovieId;
        this.Availability = Availability;
    }
}

export class SeatDBModel {
    Number: Number;
    ShowTime : String;
    TheatreId: Number;
    MovieId : Number;
    TicketId: Number;
    Availability: String;
    constructor(
        Number: Number,
        ShowTime : String,
        TheatreId: Number,
        MovieId : Number,
        TicketId: Number,
        Availability: String
    ) {
        this.Number = Number;
        this.ShowTime = ShowTime;
        this.TheatreId = TheatreId;
        this.MovieId = MovieId;
        this.TicketId = TicketId;
        this.Availability = Availability;
    }
}

export class TicketModel {
    Id: Number;
    UserName: String;
    NumberOfSeats: Number;
    ShowTime: String;
    TheatreId: Number;
    MovieId: Number;
    constructor(
        Id: Number,
        UserName: String,
        NumberOfSeats: Number,
        ShowTime: String,
        TheatreId: Number,
        MovieId: Number
    ) {
        this.Id = Id;
        this.UserName = UserName;
        this.NumberOfSeats = NumberOfSeats;
        this.ShowTime = ShowTime;
        this.TheatreId = TheatreId;
        this.MovieId = MovieId;
    }
}
