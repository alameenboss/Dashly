import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ConfiramtionComponent } from 'src/app/shared/components/confiramtion/confiramtion.component';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { environment } from 'src/environments/environment';
import { Webapp } from '../../models/Webapp.model';
import { WebappService } from '../../services/webapp.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input('ShowImage') showImage: boolean = true;
  @Input('AllowEdit') allowEdit: boolean = false;
  @Input('Webapp') webapp: Webapp;
  @Output() cardDeleted : EventEmitter<void>= new EventEmitter();
  imageUrl: string;
  
  constructor(private fileUploadService: FileUploadService,
    private webappService: WebappService,
    public dialog: MatDialog,
    public toasterService: ToasterService,
    public router: Router) { }

  ngOnInit(): void {
    this.createImgPath(this.webapp);
  }
  createImgPath(data: Webapp): void {
    if (data?.attachments?.length > 0) {
      let serverPath = data?.attachments?.filter(x => x.isPrimary);
      let fileUrl: string = ''
      if (serverPath.length > 0) {
        fileUrl = serverPath[0].name
      } else {
        fileUrl = data?.attachments[0].name
      }
      this.imageUrl = `${environment.fileUrl}/${fileUrl}`;
    }
    return undefined;
  }

  editWebapp(id: number) {
    this.router.navigateByUrl(`webapp/edit/${id}`);
  }

  removeWebapp(id: number) {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      data: { id: id },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.webappService.delete(id).subscribe(data => {
          this.toasterService.openSnackBar('Deleted Succesfully!', 'Ok');
          //this.getAllTemplate();
          this.cardDeleted.emit();
        });
      }
    });
  }

  deleteFile(index: number) {
    this.files.splice(index, 1);
  }

  files: any[] = [];
  progress: number;
  onFileDropped(filelist: File[]) {
    if (filelist.length > 0) {
      let _f = filelist[0];
      this.fileUploadService.uploadfile(_f).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          setTimeout(() => {
            this.progress = 0;
            this.deleteFile(this.files.indexOf(_f))
          }, 200);
          let res = event.body;
          this.imageUrl = `${environment.fileUrl}/${res.toString()}`;
          this.webappService.addAtachment(this.webapp.id, res.toString()).subscribe(x => {

          })

        }
      });
    }
  }
}
