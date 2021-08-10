import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  movieName: string;
  cities: Array<string> = ["Hyderabad","Delhi","Bangalore","Mumbai"];
  selectedCity: string = this.cities[0];

  ngOnInit() {
    // take cities from shared service, from database
  }

  searchMovies() {
    alert(this.selectedCity);
  }
}
