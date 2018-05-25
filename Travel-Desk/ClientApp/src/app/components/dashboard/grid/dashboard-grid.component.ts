import { Component, ViewChild,OnInit } from '@angular/core';
import { MatPaginatorModule,MatFormFieldModule, MatButtonModule, MatSortModule, MatDialogModule, MatTableModule } from '@angular/material';
import { MatPaginator, MatSort,MatDialog } from '@angular/material';
import { RequestService } from '../../../shared/services/request.service'
import { RequestData } from '../../../shared/models/requestdata.interface';
import { ReimbursementData } from '../../../shared/models/reimbursementdata.interface';
import { RequestDialog } from '../../request/request-dialog.component';
import { ReimbursementDialog } from '../../reimbursement/reimbursement-dialog.component';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridService } from '../../../shared/services/grid.service';
import { CollectionViewer } from '@angular/cdk/collections';
import { catchError, finalize, tap } from 'rxjs/operators';
import { MatProgressSpinnerModule } from '@angular/material';
import { of } from 'rxjs/observable/of';
import { ActivatedRoute } from '@angular/router';

/**
 * @title Data table with sorting, pagination, and filtering.
 */
@Component({
    selector: 'dash-grid',
    styleUrls: ['dashboard-grid.component.css'],
    templateUrl: 'dashboard-grid.component.html',
})
export class TableOverviewExample implements OnInit {

    displayedColumns = ['requestId', 'project_Code', 'country', 'employeeId', 'employeeName', 'travelDate', 'returnDate','actions'];
    dataSource: RequestDataSource;
    length=0;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(public dialog: MatDialog, private requestService: RequestService,
      private route: ActivatedRoute
    ) {
        // Create 100 users
        
        
    }
    
    /**
     * Set the paginator and sort after the view init since this component will
     * be able to query its view for the initialized paginator and sort.
     */
    ngAfterViewInit() {
      this.paginator.page
            .pipe(
                tap(() => this.loadRequestPage())
            )
            .subscribe();

      this.paginator.length = this.length;
      
    }

    ngOnInit() {
        
        this.dataSource = new RequestDataSource(this.requestService);
        this.dataSource.loadRequests();
        this.length = this.dataSource.getRequestlength();
        

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

            this.dataSource.loadRequests();

        });

                  
        
    }


    
    loadRequestPage() {

      this.dataSource.loadRequests(
              '',
            'asc',
            this.paginator.pageIndex,
            this.paginator.pageSize);
      
    }


}

/** Builds and returns a new User. */
export class RequestDataSource implements DataSource<any>
{

  private requestSubject = new BehaviorSubject<RequestData[]>([]);
  private loadingRequestSubject = new BehaviorSubject<boolean>(false);
  public loading$ = this.loadingRequestSubject.asObservable();
  private requestLength= 0;

  constructor(private requestService: RequestService) {
        
    }
    connect(collectionViewer: CollectionViewer): Observable<RequestData[]> {
      return this.requestSubject.asObservable();
    }
    disconnect(collectionViewer: CollectionViewer): void {
      this.requestSubject.complete();
      this.loadingRequestSubject.complete();
    }

    getRequestlength() {

      return this.requestLength;
    }

    loadRequests(filter = '',
    sortDirection = 'asc', pageIndex = 0, pageSize = 3) {
        this.loadingRequestSubject.next(true);
    this.requestService.getRequestList(filter, sortDirection,
      pageIndex, pageSize).pipe(
        catchError(() => of([])),
        finalize(() => this.loadingRequestSubject.next(false))
      )
      .subscribe(request => {
        this.requestLength = request.length;
        this.requestSubject.next(request);

      });
            
        
    }

}

