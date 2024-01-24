import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { DataImportService } from '../data-import.service';

@Component({
  selector: 'app-impoter',
  templateUrl: './impoter.component.html',
  styleUrls: ['./impoter.component.scss']
})
export class ImpoterComponent implements OnInit {
  files: any[] = [];
  
  importType:string;

  constructor(
    private toasterService: ToasterService,
    private dataImportService: DataImportService) {
  }
  ngOnInit(): void { 
    
  }

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
      this.dataImportService.import(this.importType, _f).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          _f.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          this.onUploadFinished.emit(event.body);
          setTimeout(() => { 
            this.deleteFile(this.files.indexOf(_f));
            this.toasterService.openSnackBar("Data imported successfully", null);
          }, 200);
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
