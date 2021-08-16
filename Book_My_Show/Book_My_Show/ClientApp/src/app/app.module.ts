import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MovieBannerCarouselComponent } from './home/movie-banner-carousel/movie-banner-carousel.component';
import { AdminComponent } from './admin/admin.component';
import { AddTheatreComponent } from './admin/add-theatre/add-theatre.component';
import { AddMovieComponent } from './admin/add-movie/add-movie.component';
import { AddShowComponent } from './admin/add-show/add-show.component';
import { AddBannerImageComponent } from './admin/add-banner-image/add-banner-image.component';
import { ViewMoviesComponent } from './view-movies/view-movies.component';
import { ViewMoviesCardsComponent } from './view-movies-cards/view-movies-cards.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MovieBannerCarouselComponent,
    AdminComponent,
    AddTheatreComponent,
    AddMovieComponent,
    AddShowComponent,
    AddBannerImageComponent,
    ViewMoviesComponent,
    ViewMoviesCardsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'addTheatre', component: AddTheatreComponent},
      { path: 'addMovie', component: AddMovieComponent},
      { path: 'addShow', component: AddShowComponent},
      { path: 'addBannerImage', component: AddBannerImageComponent},
      { path: 'viewMovies/:city/:movie', component: ViewMoviesComponent}
    ]), 
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
