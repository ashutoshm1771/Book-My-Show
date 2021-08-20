import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { movieModel } from '../ViewModels';

@Component({
  selector: 'app-view-movies-cards',
  templateUrl: './view-movies-cards.component.html',
  styleUrls: ['./view-movies-cards.component.scss']
})
export class ViewMoviesCardsComponent implements OnInit {

  @Input('city') city: string;
  @Input('movie') movie: string;

  http: HttpClient;
  baseUrl: string;
  shows: any = [];
  apiCity: string = '';
  apiMovie : string = '';
  currentMovieIds: any = [];
  movieIds: any = [];
  currentMovie: movieModel;
  movies: any = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.getShows();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getShows();
  }

  getShows() {
    (this.city == "") ? this.apiCity = "-1" : this.apiCity = this.city;
    (this.movie == "") ? this.apiMovie = "-1" : this.apiMovie = this.movie;
    this.http.get<any[]>(this.baseUrl + 'api/show/movieName/' + this.apiMovie + '/city/' + this.apiCity).subscribe(result => {
      this.shows = result;
    }, error => console.error(error));
  }

  displayMovie(show) : void{
    this._router.navigate( ['viewMovie', show.Id, this.city ]);
  }

}
