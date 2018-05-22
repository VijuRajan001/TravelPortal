import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { RequestService} from './request.service';
import { from } from 'rxjs/observable/from'; 
@Injectable()
export class GridService {
    constructor(private requestService: RequestService,) {  }

    private gridDataSource = new BehaviorSubject<any[]>([]);

   gridData = this.gridDataSource.asObservable();

   pushGridData(data:any) {
      this.gridDataSource.next(data);
    }

    getGridData(): Observable<any>
    {
        return this.gridData;
    }

    disconnect(): any
    {
        this.gridDataSource.complete();
    }

    loadGridData(): void {

        this.requestService.getRequestList().subscribe(requests => this.pushGridData(requests));
    }

}