import { Component, OnInit, Input } from '@angular/core';
import {CategoriesService } from '../services/categories.service'
import { PicturesService } from '../services/pictures.service';
import { Category } from '../model/category';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-picture',
  templateUrl: './edit-picture.component.html',
  styleUrls: ['./edit-picture.component.css']
})
export class EditPictureComponent implements OnInit {

  @Input() pictureBeingEditId: Number;

  editForm: FormGroup;
  categoriesList: Category[];

  constructor(private formBuilder: FormBuilder, private picturesService: PicturesService, private categoriesService: CategoriesService, private router: Router) { }

  ngOnInit() {
    this.categoriesService.getAll().subscribe(data => { this.categoriesList = data; });

    this.editForm = this.formBuilder.group({
      id: [],
      description: ['', Validators.maxLength(200)],
      categoryId: [0, Validators.min(1)],
    });
  }

  back() {
    this.router.navigate(['list-picture']);
  }

  onSubmit() {
    this.picturesService.create(this.editForm.value).subscribe(data => { this.router.navigate(['list-picture']); });
  }
}
