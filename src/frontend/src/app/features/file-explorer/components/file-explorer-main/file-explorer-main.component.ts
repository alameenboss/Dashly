import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FileElement, FileExplorerService } from '../../services/file-explorer.service';

@Component({
  selector: 'app-file-explorer-main',
  templateUrl: './file-explorer-main.component.html',
  styleUrls: ['./file-explorer-main.component.scss']
})
export class FileExplorerMainComponent implements OnInit, OnDestroy {

  public fileElements: Observable<FileElement[]>;

  constructor(public fileExplorerService: FileExplorerService) { }

  ngOnDestroy(): void {
    this.fileExplorerService.clear();
    this.updateFileElementQuery();
  }

  currentRoot: FileElement;
  currentPath: string;
  canNavigateUp = false;

  ngOnInit() {
    this.fileExplorerService.getRootDirectories().subscribe((res: any[]) => {
      res?.forEach(dir => {
        this.fileExplorerService.add({ name: dir.replace("\\","") , itemType: 'drive', parent: 'root' })
      });
      this.updateFileElementQuery();
    })

  }

  addFolder(folder: { name: string }) {
    this.fileExplorerService.add({ itemType: 'folder', name: folder.name, parent: this.currentRoot ? this.currentRoot.id : 'root' });
    this.updateFileElementQuery();
  }

  removeElement(element: FileElement) {
    this.fileExplorerService.delete(element.id);
    this.updateFileElementQuery();
  }

  navigateToFolder(element: FileElement) {
    this.currentRoot = element;
    this.updateFileElementQuery();
    this.currentPath = this.pushToPath(this.currentPath, element.name);
    console.log(element)
    this.fileExplorerService.getFiles(this.currentPath).subscribe((res:any)=>{
      console.log(res)
      res.folders?.forEach(folder => {
        this.fileExplorerService.add({ name: folder , itemType: 'folder', parent: element.id })
      });
      res.files?.forEach(file => {
        this.fileExplorerService.add({ name: file , itemType: 'file', parent: element.id })
      });
      
      this.updateFileElementQuery();
    })
    this.canNavigateUp = true;
  }

  navigateUp() {
    if (this.currentRoot && this.currentRoot.parent === 'root') {
      this.currentRoot = null;
      this.canNavigateUp = false;
      this.updateFileElementQuery();
    } else {
      this.currentRoot = this.fileExplorerService.get(this.currentRoot.parent);
      this.updateFileElementQuery();
    }
    this.currentPath = this.popFromPath(this.currentPath);
  }

  moveElement(event: { element: FileElement; moveTo: FileElement }) {
    this.fileExplorerService.update(event.element.id, { parent: event.moveTo.id });
    this.updateFileElementQuery();
  }

  renameElement(element: FileElement) {
    this.fileExplorerService.update(element.id, { name: element.name });
    this.updateFileElementQuery();
  }

  updateFileElementQuery() {
    this.fileElements = this.fileExplorerService
      .queryInFolder(this.currentRoot ? this.currentRoot.id : 'root');
  }

  pushToPath(path: string, folderName: string) {
    let p = path ? path : '';
    p += `${folderName}/`;
    return p;
  }

  popFromPath(path: string) {
    let p = path ? path : '';
    let split = p.split('/');
    split.splice(split.length - 2, 1);
    p = split.join('/');
    return p;
  }

}
