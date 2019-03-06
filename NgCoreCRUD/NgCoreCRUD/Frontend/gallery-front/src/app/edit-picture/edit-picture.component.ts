import { Component, OnInit, Input } from '@angular/core';
import {CategoriesService } from '../services/categories.service'
import { PicturesService } from '../services/pictures.service';
import { Category } from '../model/category'
import { Picturevm } from '../model/picturevm'

@Component({
  selector: 'app-edit-picture',
  templateUrl: './edit-picture.component.html',
  styleUrls: ['./edit-picture.component.css']
})
export class EditPictureComponent implements OnInit {

  @Input() pictureBeingEditId: Number;

  constructor() { }

  ngOnInit() {
  }

}
