import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTheatresComponent } from './view-theatres.component';

describe('ViewTheatresComponent', () => {
  let component: ViewTheatresComponent;
  let fixture: ComponentFixture<ViewTheatresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewTheatresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTheatresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
