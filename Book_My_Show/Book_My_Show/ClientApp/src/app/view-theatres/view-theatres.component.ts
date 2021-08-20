import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-theatres',
  templateUrl: './view-theatres.component.html',
  styleUrls: ['./view-theatres.component.scss']
})
export class ViewTheatresComponent implements OnInit {

  apiCity: string;
  city: string;
  movieId: string;
  movie: any;
  theatreShows: any[];
  theatreView = new Map();

  constructor(private _Activatedroute:ActivatedRoute,http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._Activatedroute.paramMap.subscribe(params => {
      this.city = params.get('city');
      this.movieId = params.get('movieId');
    });
    (this.city == "") ? this.apiCity = "-1" : this.apiCity = this.city;
    http.get<any>(baseUrl + 'api/movie/' + this.movieId).subscribe(result => {
      this.movie = result;
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/show/movie/' + this.movieId + '/city/' + this.apiCity).subscribe(result => {
      this.theatreShows = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
