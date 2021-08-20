import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-movie',
  templateUrl: './view-movie.component.html',
  styleUrls: ['./view-movie.component.scss']
})
export class ViewMovieComponent implements OnInit {

  city: string;
  movieId: string;
  movie: any;

  constructor(private _Activatedroute:ActivatedRoute,http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._Activatedroute.paramMap.subscribe(params => {
      this.city = params.get('city');
      this.movieId = params.get('movie');
    });
    http.get<any>(baseUrl + 'api/movie/' + this.movieId).subscribe(result => {
      this.movie = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
