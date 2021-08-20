import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { movieModel, SeatModel, showModel, theatreModel } from 'src/app/ViewModels';

@Component({
  selector: 'app-add-show',
  templateUrl: './add-show.component.html',
  styleUrls: ['./add-show.component.scss']
})
export class AddShowComponent implements OnInit {

  http: HttpClient;
  baseUrl: string;
  movies : any = [];
  theatres: any = [];
  showTimes: any = ['6 AM','9 AM','12 PM','3 PM','6 PM','9 PM'];
  currentShow: showModel = new showModel("",0,0);
  currentMovie: any = new movieModel(0,"",0,"","","","","","");
  currentTheatre: any = new theatreModel(0,"","",0);


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,private _router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<any[]>(baseUrl + 'api/movie').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/theatre').subscribe(result => {
      this.theatres = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  addShow(){
    let index = this.movies.findIndex(x => x.Name === this.currentMovie.Name);
    this.currentShow.MovieId = this.movies[index].Id;
    index = this.theatres.findIndex(x => x.Name === this.currentTheatre.Name);
    this.currentShow.TheatreId = this.theatres[index].Id;
    this.http.post(this.baseUrl + 'api/show',this.currentShow).subscribe(result => {
      alert(result);
    }, error => console.error(error));
    for(let i = 1 ; i <= 200 ; i++)
    {
      var currentSeat: SeatModel = new SeatModel(i,this.currentShow.Time,this.currentShow.TheatreId,this.currentShow.MovieId,'Available');
      this.http.post(this.baseUrl + 'api/seat',currentSeat).subscribe(result => {}, error => console.error(error));
    }
    this._router.navigate(['/admin']);
  }
}
