import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { theatreModel } from 'src/app/ViewModels';

@Component({
  selector: 'app-add-theatre',
  templateUrl: './add-theatre.component.html',
  styleUrls: ['./add-theatre.component.scss']
})
export class AddTheatreComponent implements OnInit {

  currentTheatre: theatreModel = new theatreModel(0,"","",1);
  Name: string;
  addTheatreForm!: FormGroup;
  http: HttpClient;
  baseUrl: string;
  cities: any = ['Hyderabad','Delhi','Mumbai','Bangalore','Chennai','Pune','Kolkata'];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,private _router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
   }

  ngOnInit() {
  }

  addTheatre() : void {
    if(this.currentTheatre.Name.length > 0 && this.currentTheatre.City.length > 0 && this.currentTheatre.NumberOfHalls > 0){
      var newTheatreObject: theatreModel = new theatreModel(0,this.currentTheatre.Name,this.currentTheatre.City,this.currentTheatre.NumberOfHalls)
      this.http.post(this.baseUrl + 'api/theatre',newTheatreObject).subscribe(result => {
        alert(result);
      }, error => console.error(error));
      this._router.navigate(['/admin']);
    } else {
      alert("Please enter all values.");
    }
  }
}
