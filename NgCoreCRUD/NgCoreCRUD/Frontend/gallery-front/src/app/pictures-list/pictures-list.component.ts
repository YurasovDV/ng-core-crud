import { Component, OnInit } from '@angular/core';
import { PicturesService } from '../services/pictures.service';
import { Picturevm } from '../model/picturevm';

@Component({
  selector: 'app-pictures-list',
  templateUrl: './pictures-list.component.html',
  styleUrls: ['./pictures-list.component.css']
})
export class PicturesListComponent implements OnInit {

  pictures: Picturevm[];

  constructor(private picService: PicturesService) { }

  ngOnInit() {
    this.picService.getAll().subscribe(data => this.pictures = data);
  }

}
