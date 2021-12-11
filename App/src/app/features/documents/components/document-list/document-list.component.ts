import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfiramtionComponent } from 'src/app/shared/components/confiramtion/confiramtion.component';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { DocumentService } from '../../services/document.service';
import { v4 as uuidV4 } from "uuid";

@Component({
  selector: 'app-document-list',
  templateUrl: './document-list.component.html',
  styleUrls: ['./document-list.component.scss']
})
export class DocumentListComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<any>;
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['docid', 'content', 'action'];

  constructor(
    public router: Router,
    public toasterService: ToasterService,
    public dialog: MatDialog,
    public documentService: DocumentService) {
  }
  ngOnInit(): void {
    this.getAllDocuments();
  }

  public getAllDocuments() {
    this.documentService.getAll().subscribe((res: any[]) => {

      if (res != null) {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.table.dataSource = this.dataSource;
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteAll() {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      data: { id: 0 },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.documentService.deleteAll().subscribe(data => {
          this.toasterService.openSnackBar('Deleted Succesfully!', 'Ok');
          this.getAllDocuments();
        });
      }
    });
  }

  add() {
    this.router.navigateByUrl(`documents/edit/${uuidV4()}`);
  }

  edit(id: string) {
    this.router.navigateByUrl(`documents/edit/${id}`);
  }

  delete(id: string) {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      data: { id: id },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.documentService.deleteByDocId(id).subscribe(data => {
          this.toasterService.openSnackBar('Deleted Succesfully!', 'Ok');
          this.getAllDocuments();
        });
      }
    });
  }

  deleteAllWebapp() {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.documentService.deleteAll().subscribe(data => {
          this.toasterService.openSnackBar('All apps deleted succesfully!', 'Ok');
          this.getAllDocuments();
        });
      }
    });
  }
}
