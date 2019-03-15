import { Component, OnInit, Input } from '@angular/core';
import { CategoriesService } from '../services/categories.service'
import { PicturesService } from '../services/pictures.service';
import { Category } from '../model/category';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Picturevm } from '../model/picturevm';

@Component({
  selector: 'app-edit-picture',
  templateUrl: './edit-picture.component.html',
  styleUrls: ['./edit-picture.component.css']
})
export class EditPictureComponent implements OnInit {

  editForm: FormGroup;
  categoriesList: Category[];
  pictureVm: Picturevm;

  constructor(private formBuilder: FormBuilder, private picturesService: PicturesService, private categoriesService: CategoriesService, private router: Router, private route: ActivatedRoute) {
    this.pictureVm = new Picturevm(0, '', 0, '');
  }

  ngOnInit() {
    this.categoriesService.getAll().subscribe(data => { this.categoriesList = data; });

    this.editForm = this.formBuilder.group({
      id: [],
      categoryName: [],
      file: [],
      url: [],
      description: ['', Validators.maxLength(200)],
      categoryId: [0, Validators.min(1)],
    });

    this.route.paramMap.subscribe(params => {
      let pictureBeingEditId = +params.get('id');

      this.picturesService.getPicture(pictureBeingEditId).subscribe(data => {
        this.editForm.setValue(data);
        this.pictureVm = data;
      });
    });
  }

  back() {
    this.router.navigate(['list-picture']);
  }

  onSubmit() {
    this.picturesService.update(this.editForm.value).subscribe(data => { this.router.navigate(['list-picture']); });
  }
}
