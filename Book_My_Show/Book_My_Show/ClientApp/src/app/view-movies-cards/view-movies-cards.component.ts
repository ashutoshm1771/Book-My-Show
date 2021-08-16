import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit, SimpleChanges } from '@angular/core';
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

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.getShows();
    this.getMovies();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getShows();
    this.getMovies();
  }

  getShows() {
    (this.city == "") ? this.apiCity = "-1" : this.apiCity = this.city;
    (this.movie == "") ? this.apiMovie = "-1" : this.apiMovie = this.movie;
    this.http.get<any[]>(this.baseUrl + 'api/show/getByMovieAndCity/' + this.apiMovie + '/' + this.apiCity).subscribe(result => {
      this.shows = result;
    }, error => console.error(error));
  }

  getMovies() : void {
    this.currentMovieIds = this.shows.map(({ MovieId }) => MovieId);
    this.movieIds = [...new Set(this.currentMovieIds)];
    for(let movieId in this.movieIds) {
      this.http.get<any>(this.baseUrl + 'api/movie/' + movieId).subscribe(result => {
        this.currentMovie = result;
      }, error => console.error(error));
      this.movies.push(this.currentMovie);
    }
  }

  disp() {
    alert(this.movies.length);
  }

}
