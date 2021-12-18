import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FileExplorerMainComponent } from './components/file-explorer-main/file-explorer-main.component';

const routes: Routes = [
  {
    path: '', component: FileExplorerMainComponent,
    data: {
      breadcrumb: ''
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FileExplorerRoutingModule { }
