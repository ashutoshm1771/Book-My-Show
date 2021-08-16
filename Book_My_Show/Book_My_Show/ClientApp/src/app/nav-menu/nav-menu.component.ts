import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  movieName: string = "";
  cities: Array<string> = ["Hyderabad","Delhi","Bangalore","Mumbai","Chennai","Pune","Kolkata"];
  selectedCity: string = "";

  constructor(private _router: Router) {}

  ngOnInit() {
  }

  searchMovies() {
    this._router.navigate( ['viewMovies',  this.selectedCity , this.movieName ]);
  }
}
