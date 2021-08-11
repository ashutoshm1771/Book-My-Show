import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss']
})
export class AddMovieComponent implements OnInit {

  coverPhotoUrl: string = "/assets/img/default-image.png";
  coverPhotoFile: File = null;

  constructor() { }

  ngOnInit() {
  }

  handleCoverPhotoInput(file: FileList) {
    this.coverPhotoFile = file.item(0);
    //Show image preview
    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.coverPhotoUrl = event.target.result;
    }
    reader.readAsDataURL(this.coverPhotoFile);
  }

}
