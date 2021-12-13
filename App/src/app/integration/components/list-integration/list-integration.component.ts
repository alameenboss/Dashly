import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfiramtionComponent } from 'src/app/shared/components/confiramtion/confiramtion.component';
import { ToasterService } from 'src/app/shared/services/toaster.service';
import { Integration } from '../../models/Integration.model';
import { IntegrationService } from '../../services/integration.service';

@Component({
  selector: 'app-list-integration',
  templateUrl: './list-integration.component.html',
  styleUrls: ['./list-integration.component.scss']
})
export class ListIntegrationComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Integration>;
  dataSource: MatTableDataSource<Integration>;
  expandedRow: Integration | null;

  displayedColumns = ['id', 'name','process', 'action'];

  constructor(
    private integrationService: IntegrationService,
    public router: Router,
    public toasterService: ToasterService,
    public dialog: MatDialog) { }

  ngAfterViewInit(): void {
    this.getAllIntegration()
  }


  public getAllIntegration() {
    this.integrationService.getAll().subscribe((res: Integration[]) => {
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

  addIntegration() {
    this.router.navigateByUrl(`integration/add`);
  }

  editIntegration(id: number) {
    this.router.navigateByUrl(`integration/edit/${id}`);
  }

  syncIntegration(id: number) {

  }

  reIntegrate(id: number) {

  }

  removeIntegration(id: number) {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      data: { id: id },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.integrationService.delete(id).subscribe(data => {
          this.toasterService.openSnackBar('Deleted Succesfully!', 'Ok');
          this.getAllIntegration();
        });
      }
    });
  }

  deleteAllIntegration() {
    const dialogRef = this.dialog.open(ConfiramtionComponent, {
      width: '400px',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.integrationService.deleteAll().subscribe(data => {
          this.toasterService.openSnackBar('All apps deleted succesfully!', 'Ok');
          this.getAllIntegration();
        });
      }
    });
  }
}
