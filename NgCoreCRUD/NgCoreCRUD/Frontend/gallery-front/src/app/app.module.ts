import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AddPictureComponent } from './add-picture/add-picture.component';
import { EditPictureComponent } from './edit-picture/edit-picture.component';
import { PicturesListComponent } from './pictures-list/pictures-list.component';
import { routing } from './app.routing';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PicturesService } from './services/pictures.service';
import { CategoriesService } from './services/categories.service';
import { AppConfig } from './app.config';

@NgModule({
  declarations: [
    AppComponent,
    AddPictureComponent,
    EditPictureComponent,
    PicturesListComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    routing
  ],
  providers: [PicturesService, AppConfig, CategoriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
