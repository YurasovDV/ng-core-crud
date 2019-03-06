import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Simple Gallery';
  public pictureBeingEditId: Number = null;

  public onPictureEditChange($event) {
    this.pictureBeingEditId = $event;
  }

}
