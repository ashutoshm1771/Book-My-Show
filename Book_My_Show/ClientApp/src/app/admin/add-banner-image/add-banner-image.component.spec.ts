import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBannerImageComponent } from './add-banner-image.component';

describe('AddBannerImageComponent', () => {
  let component: AddBannerImageComponent;
  let fixture: ComponentFixture<AddBannerImageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBannerImageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBannerImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
