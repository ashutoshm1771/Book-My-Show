import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMoviesCardsComponent } from './view-movies-cards.component';

describe('ViewMoviesCardsComponent', () => {
  let component: ViewMoviesCardsComponent;
  let fixture: ComponentFixture<ViewMoviesCardsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewMoviesCardsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMoviesCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
