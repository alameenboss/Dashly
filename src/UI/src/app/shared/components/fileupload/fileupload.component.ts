import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FileUploadService } from '../../services/file-upload.service';

@Component({
  selector: 'app-fileupload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.scss']
})
export class FileuploadComponent {

  constructor(private fileUploadService: FileUploadService) {
    
    
  }
  files: any[] = [];

  onFileDropped($event) {
    this.prepareFilesList($event);
  }

  fileBrowseHandler(target) {
    this.prepareFilesList(target.files);
  }

  deleteFile(index: number) {
    this.files.splice(index, 1);
  }

  @Output() public onUploadFinished = new EventEmitter();
  
  prepareFilesList(files: Array<any>) {
    for (const item of files) {
      item.progress = 0;
      this.files.push(item);
      
    }
    this.files.forEach(_f => {
      this.fileUploadService.uploadfile(_f).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          _f.progress  = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          this.onUploadFinished.emit(event.body);
            setTimeout(() => {this.deleteFile(this.files.indexOf(_f))}, 200);
          
        }
      });
    });
    
  }

  formatBytes(bytes, decimals) {
    if (bytes === 0) {
      return '0 Bytes';
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }
}
