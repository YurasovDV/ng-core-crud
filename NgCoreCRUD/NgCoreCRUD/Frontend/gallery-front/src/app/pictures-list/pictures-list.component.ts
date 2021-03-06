import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PicturesService } from '../services/pictures.service';
import { Picturevm } from '../model/picturevm';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-pictures-list',
  templateUrl: './pictures-list.component.html',
  styleUrls: ['./pictures-list.component.css']
})
export class PicturesListComponent implements OnInit {

  pictures: Picturevm[];

  constructor(private picService: PicturesService, private router: Router) {
    this.pictures = [];
  }

  ngOnInit() {
    this.picService.getAll().subscribe(data => this.pictures = data);
  }

  public createNew() {
    this.router.navigate(['add-picture']);
  }

  public editPicture(picture: Picturevm) {
    this.router.navigate(['edit-picture/' + picture.id ]);
  }

  public deletePicture(picture: Picturevm) {
    this.picService.deletePicture(picture.id)
      .subscribe(data => this.pictures = this.pictures.filter(p => p != picture));
  }



}
