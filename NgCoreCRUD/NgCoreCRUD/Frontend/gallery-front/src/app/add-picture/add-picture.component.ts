import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../services/categories.service';
import { PicturesService } from '../services/pictures.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../model/category';

@Component({
  selector: 'app-add-picture',
  templateUrl: './add-picture.component.html',
  styleUrls: ['./add-picture.component.css']
})
export class AddPictureComponent implements OnInit {

  addForm: FormGroup;
  categoriesList: Category[];

  constructor(private formBuilder: FormBuilder, private picturesService: PicturesService, private categoriesService: CategoriesService, private router: Router) { }

  ngOnInit() {
    this.categoriesService.getAll().subscribe(data => { this.categoriesList = data; });

    this.addForm = this.formBuilder.group({
      id: [],
      description: ['', Validators.maxLength(200)],
      categoryId: [0, Validators.min(1)],
    });
  }

  back() {
    this.router.navigate(['list-picture']);
  }

  onSubmit() {
    this.picturesService.create(this.addForm.value).subscribe(data => { this.router.navigate(['list-picture']); });
  }
}
