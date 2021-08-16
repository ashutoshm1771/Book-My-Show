import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { movieModel } from 'src/app/ViewModels';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss']
})
export class AddMovieComponent implements OnInit {

  http: HttpClient;
  baseUrl: string;
  currentMovie: movieModel = new movieModel(0,"",0,"","","2000/01/01","","","");
  categories: any = ['Hoolywood','Bollywood','Tollywood','Kollywood'];
  genres: any = ['Comedy','Horror','Thriller','Love','Romance'];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,private _router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
   }

  ngOnInit() {
  }

  addMovie() : void {
    this.http.post(this.baseUrl + 'api/movie',this.currentMovie).subscribe(result => {
      alert(result);
    }, error => console.error(error));
    this._router.navigate(['/admin']);
  }

}
