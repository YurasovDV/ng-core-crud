import { RouterModule, Route } from '@angular/router';
import { EditPictureComponent } from './edit-picture/edit-picture.component';
import { PicturesListComponent } from './pictures-list/pictures-list.component';
import { AddPictureComponent } from './add-picture/add-picture.component';

const routes: Route[] = [
  { path: 'list-picture', component: PicturesListComponent },
  { path: 'edit-picture', component: EditPictureComponent },
  { path: 'add-picture', component: AddPictureComponent },
  { path: '', component: PicturesListComponent }
];

export const routing = RouterModule.forRoot(routes);
