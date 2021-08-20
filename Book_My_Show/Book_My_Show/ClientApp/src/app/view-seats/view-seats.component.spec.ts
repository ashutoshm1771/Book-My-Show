import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSeatsComponent } from './view-seats.component';

describe('ViewSeatsComponent', () => {
  let component: ViewSeatsComponent;
  let fixture: ComponentFixture<ViewSeatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSeatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSeatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
