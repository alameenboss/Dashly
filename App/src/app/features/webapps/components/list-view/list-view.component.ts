import { trigger, state, style, transition, animate } from '@angular/animations';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfiramtionComponent } from 'src/app/shared/components/confiramtion/confiramtion.component';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { environment } from 'src/environments/environment';
import { Webapp as Webapp } from "../../models/Webapp.model";
import { WebappService } from '../../services/webapp.service';

@Component({
  selector: 'app-list-view',
  templateUrl: './list-view.component.html',
  styleUrls: ['./list-view.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ListViewComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Webapp>;
  dataSource: MatTableDataSource<Webapp>;
  expandedRow: Webapp | null;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'tags', 'action'];

  constructor(public router: Router,
    public toasterService: ToasterService,
    public webappService: WebappService,
    public dialog: MatDialog) {
  }

  ngAfterViewInit(): void {
    this.getAllTemplate();
  }

  public getAllTemplate() {
    this.webappService.getAll().subscribe((res: Webapp[]) => {

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

  addwebapp() {
    this.router.navigateByUrl(`webapp/add`);
  }

  editwebapp(id: number) {
    this.router.navigateByUrl(`webapp/edit/${id}`);
  }

  removewebapp(id: number) {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      data: { id: id },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.webappService.delete(id).subscribe(data => {
          this.toasterService.openSnackBar('Deleted Succesfully!', 'Ok');
          this.getAllTemplate();
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
        this.webappService.deleteAll().subscribe(data => {
          this.toasterService.openSnackBar('All apps deleted succesfully!', 'Ok');
          this.getAllTemplate();
        });
      }
    });
  }

  expandRow(row) {
    this.expandedRow = this.expandedRow === row ? null : row
  }

  public createImgPath = (data: Webapp) => {
    if (data?.attachments?.length > 0) {
      let serverPath = data.attachments[0].name;
      return `${environment.fileUrl}/${serverPath}`;
    }
    return undefined;
  }
}
