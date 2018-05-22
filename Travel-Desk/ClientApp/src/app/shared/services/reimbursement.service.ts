import { Injectable } from '@angular/core';

import { AppHttpService } from '../services/http.service';
import { ConfigService } from '../utils/config.service';
import { AuthService } from '../services/auth.service';
import {HttpClient,HttpParams} from '@angular/common/http';
import {BaseService} from "./base.service";
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { TravelData} from '../models/traveldata.interface';
import { ReimbursementData } from '../models/reimbursementdata.interface';
//import * as _ from 'lodash';
// Add the RxJS Observable operators we need in this app.
import '../../rxjs-operators';

@Injectable()

export class ReimbursementService extends BaseService {

  baseUrl: string = '';
  private loggedIn = false;

  constructor(private http: HttpClient , private configService: ConfigService,private authService : AuthService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  addRequest(reimbursementData: ReimbursementData): Observable<any> {
      return this.http.post(this.baseUrl + 'api/Reimbursement/AddReimbursement',
          JSON.stringify(reimbursementData));
  }

  getRequestList(): Observable<ReimbursementData[]> {

      return this.http.get<ReimbursementData[]>(this.baseUrl + 'api/Reimbursement/GetReimbursementList');
  }

  getRequestById(id:number): Observable<ReimbursementData> {
      
      return this.http.get<ReimbursementData>(this.baseUrl + 'api/Reimbursement/GetReimbursementById', {
          params: new HttpParams().set('id', id.toString())
      }
    );
  }

  updateRequest(reimbursementData: ReimbursementData): Observable<any> {
      let travelData: TravelData = new TravelData();
      travelData.reimbursementData = reimbursementData;
      return this.http.post(this.baseUrl + 'api/Reimbursement/UpdateReimbursement', 
          JSON.stringify(travelData));
    }
}
