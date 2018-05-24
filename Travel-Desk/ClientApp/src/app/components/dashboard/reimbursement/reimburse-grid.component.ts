import { Component, ViewChild,OnInit } from '@angular/core';
import { MatPaginatorModule,MatFormFieldModule, MatButtonModule, MatSortModule, MatDialogModule, MatTableModule } from '@angular/material';
import { MatPaginator, MatSort,MatDialog } from '@angular/material';

import { RequestData } from '../../../shared/models/requestdata.interface';
import { ReimbursementData } from '../../../shared/models/reimbursementdata.interface';
import { RequestDialog } from '../../request/request-dialog.component';
import { ReimbursementDialog } from '../../reimbursement/reimbursement-dialog.component';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridService } from '../../../shared/services/grid.service';

/**
 * @title Data table with sorting, pagination, and filtering.
 */
@Component({
    selector: 'reimburse-grid',
    styleUrls: ['reimburse-grid.component.css'],
    templateUrl: 'reimburse-grid.component.html',
})
export class ReimburseGrid implements OnInit {

  displayedColumns = ['reimbursementInfoId', 'projectCode', 'employeeId','employeeName', 'purposeofTravel', 'locationofTravel','actions'];
    dataSource: ReimbursementDataSource;
    request: RequestData;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(public dialog: MatDialog, private gridService: GridService) {
        // Create 100 users
        
        
    }
    
    /**
     * Set the paginator and sort after the view init since this component will
     * be able to query its view for the initialized paginator and sort.
     */
    ngAfterViewInit() {
    //    this.dataSource.paginator = this.paginator;
    //    this.dataSource.sort = this.sort;
    }

    ngOnInit() {
        this.dataSource = new ReimbursementDataSource(this.gridService);
        this.dataSource.loadReimbursement();

    }

    applyFilter(filterValue: string) {
        //filterValue = filterValue.trim(); // Remove whitespace
        //filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
        //this.dataSource.filter = filterValue;
    }

    openRequestDialog(id:number): void {


        let dialogRef = this.dialog.open(RequestDialog, {
            width: '80vw',
            height: '70vh',
            data: id
        });

        dialogRef.afterClosed().subscribe(result => {

            this.dataSource.loadReimbursement();

        });

                  
        
    }


    openReimbursementDialog(id: number): void {


        let dialogRef = this.dialog.open(ReimbursementDialog, {
            width: '80vw',
            height: '70vh',
            data: id
        });

        dialogRef.afterClosed().subscribe(result => {

            this.dataSource.loadReimbursement();

        });



    }


}

/** Builds and returns a new User. */
export class ReimbursementDataSource extends DataSource<any>
{
    
    private loadingreimbursementSubject = new BehaviorSubject<boolean>(false);

    constructor(private gridService : GridService) {
        super();
    }
    connect(): Observable<any[]> {
        
        
        return this.gridService.getGridData();
        
    }
    disconnect() {
        this.gridService.disconnect();
        this.loadingreimbursementSubject.complete();

    }

    loadReimbursement() {
        this.loadingreimbursementSubject.next(true);
        this.gridService.loadReimbursementData();
            
        
    }

}

