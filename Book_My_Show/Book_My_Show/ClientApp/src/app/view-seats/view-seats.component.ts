import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-seats',
  templateUrl: './view-seats.component.html',
  styleUrls: ['./view-seats.component.scss']
})
export class ViewSeatsComponent implements OnInit {

  http: HttpClient;
  baseUrl: string;

  seats: any[];
  toBook: any = new Array(200).fill(0);
  movieId: string;
  theatreId: string;
  showTime: string;
  numberOfRequiredSeats: number = 1;
  maximumSeatCapacity: number = 200;
  bookedSeats: any = [];
  isButtonDisabled: boolean = true;
  remainingSeats: number = this.numberOfRequiredSeats;
  numberOfAvailableSeats: number = 0;
  userName: string = '';

  constructor(private _router: Router,private _Activatedroute:ActivatedRoute,http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._Activatedroute.paramMap.subscribe(params => {
      this.theatreId = params.get('theatreId');
      this.movieId = params.get('movieId');
      this.showTime = params.get('showTime');
    });
    http.get<any[]>(baseUrl + 'api/seat/showTime/' + this.showTime + '/movie/' + this.movieId + '/theatre/' + this.theatreId).subscribe(result => {
      this.seats = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    for(let seat of this.seats) {
      if(seat.Availability == 'Available') {
        this.numberOfAvailableSeats++;
      } 
    }
  }

  decrementNumberOfRequiredSeats() {
    (this.numberOfRequiredSeats == 1 ) ? alert("Number of Seats can not be 0") : this.numberOfRequiredSeats--, this.remainingSeats--;
  }

  incrementNumberOfRequiredSeats() {
    (this.numberOfRequiredSeats == this.numberOfAvailableSeats ) ? alert("Seats unavailable.") : this.numberOfRequiredSeats++, this.remainingSeats++;
  }

  markSeats(startIndex: number) : void {
    if(this.bookedSeats.length < this.numberOfRequiredSeats)
    {
      var endIndex = Math.min( startIndex + this.remainingSeats , (Math.floor( (startIndex )/20 ) + 1) * 20 + 1);
      for(let i=startIndex ; i < endIndex; i++)
      {
        if(this.seats[i-1].Availability == 'Available' && this.toBook[i-1] == 0)
        {
          this.toBook[i-1] = 1;
          this.bookedSeats.push(i);
          this.remainingSeats--;
          if(this.userName.length > 0 && this.bookedSeats.length == this.numberOfRequiredSeats)
          {
            this.isButtonDisabled = false;
          }
        } else {
          break;
        }
      }
    } 
    else 
    {
      alert("Seats already selected. Proceed to book!");
    }
  }

  clearSelection() : void {
    this.toBook = new Array(200).fill(0);
    this.bookedSeats = [];
    this.remainingSeats = this.numberOfRequiredSeats;
    this.isButtonDisabled = true;
  }

  getArray(i: number) : any{
    return new Array(i);
  }

  bookTicket() : void{
    this._router.navigate(['/ticket', this.userName, this.movieId, this.theatreId, this.showTime, this.bookedSeats.join(',')]);
  }

}
