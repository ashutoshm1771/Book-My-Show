import { HttpClient } from '@angular/common/http';
import { NgModule,Component, Inject, OnInit } from '@angular/core';
 import { CommonModule } from '@angular/common';
 import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-movie-banner-carousel',
  templateUrl: './movie-banner-carousel.component.html',
  styleUrls: ['./movie-banner-carousel.component.scss']
})

export class MovieBannerCarouselComponent implements OnInit {
  movies: Array<string> = ["BajrangiBhaijaan","Robot2","Kedarnath","GullyBoy"];
  coverPhotos: Array<any> = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'api/movies').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  ngOnInit() {
     
  }
  
}
