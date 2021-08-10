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