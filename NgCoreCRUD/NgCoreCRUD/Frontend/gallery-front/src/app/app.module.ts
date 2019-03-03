import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AddPictureComponent } from './add-picture/add-picture.component';
import { EditPictureComponent } from './edit-picture/edit-picture.component';
import { PicturesListComponent } from './pictures-list/pictures-list.component';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PicturesService } from './services/pictures.service';

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
    HttpClientModule
  ],
  providers: [PicturesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
