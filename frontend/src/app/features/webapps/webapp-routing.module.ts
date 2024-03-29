import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddEditWebappComponent } from "./components/add-edit-webapp/add-edit-webapp.component";
import { CardViewComponent } from "./components/card-view/card-view.component";
import { ListViewComponent } from "./components/list-view/list-view.component";

const routes: Routes = [
  {
    path: "",
    component: ListViewComponent,
    data: {
      breadcrumb: "",
    },
  },
  {
    path: "listview",
    component: ListViewComponent,
    data: {
      breadcrumb: "List",
    },
  },
  {
    path: "cardview",
    component: CardViewComponent,
    data: {
      breadcrumb: "Card",
    },
  },
  {
    path: "add",
    component: AddEditWebappComponent,
    data: {
      breadcrumb: "Add",
    },
  },
  {
    path: "edit/:id",
    component: AddEditWebappComponent,
    data: {
      breadcrumb: "Edit",
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WebappRoutingModule {}
