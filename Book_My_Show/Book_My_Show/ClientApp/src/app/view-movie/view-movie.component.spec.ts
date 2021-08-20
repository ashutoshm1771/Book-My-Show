import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMovieComponent } from './view-movie.component';

describe('ViewMovieComponent', () => {
  let component: ViewMovieComponent;
  let fixture: ComponentFixture<ViewMovieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewMovieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
