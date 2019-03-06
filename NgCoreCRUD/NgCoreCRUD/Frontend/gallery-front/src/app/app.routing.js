"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var edit_picture_component_1 = require("./edit-picture/edit-picture.component");
var pictures_list_component_1 = require("./pictures-list/pictures-list.component");
var add_picture_component_1 = require("./add-picture/add-picture.component");
var routes = [
    { path: 'list-picture', component: pictures_list_component_1.PicturesListComponent },
    { path: 'edit-picture', component: edit_picture_component_1.EditPictureComponent },
    { path: 'add-picture', component: add_picture_component_1.AddPictureComponent },
    { path: '', component: pictures_list_component_1.PicturesListComponent }
];
exports.routing = router_1.RouterModule.forRoot(routes);
//# sourceMappingURL=app.routing.js.map