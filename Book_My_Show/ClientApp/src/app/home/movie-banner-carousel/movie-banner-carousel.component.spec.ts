import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieBannerCarouselComponent } from './movie-banner-carousel.component';

describe('MovieBannerCarouselComponent', () => {
  let component: MovieBannerCarouselComponent;
  let fixture: ComponentFixture<MovieBannerCarouselComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovieBannerCarouselComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieBannerCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
