
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { RequestDialog } from './components/request/request-dialog.component'
import { TableOverviewExample } from './components/dashboard/grid/dashboard-grid.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from './components/account/login/login.component';
import { LoginLayoutComponent } from './components/layout/login/login-layout.component';
import { HomeLayoutComponent } from './components/layout/home/home-layout.component';

import { MediaMatcher } from '@angular/cdk/layout';
import { ConfigService } from './shared/utils/config.service';
import { UserService } from './shared/services/user.service';
import { RequestService } from './shared/services/request.service';
import { AuthService } from './shared/services/auth.service';
import { GridService } from './shared/services/grid.service';
import { AuthGuard } from '../app/auth.guard';
import { httpInterceptorProviders } from '../app/shared/interceptors/http.intercep.providers';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
} from '@angular/material';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';
import { FlightItemsArrayComponent } from './components/form/flightoptions/flightoptions.component';
import { FlightItemControlComponent } from './components/form/flightItems/flight-item-control.component';
import { HotelItemsArrayComponent } from './components/form/hotelOptions/hoteloptions.component';
import { HotelItemControlComponent } from './components/form/hotelItems/hotel-item-control.component';
import { FareItemsArrayComponent } from './components/form/fareOptions/fareoptions.component';
import { FareItemControlComponent } from './components/form/fareItems/fare-item-control.component';
import { BoardingLodgingItemsArrayComponent } from './components/form/boardingLodgingOptions/boardingLodgingoptions.component';
import { BoardingLodgingItemControlComponent } from './components/form/boardingLodgingItems/boardingLodging-item-control.component';
import { PerDiemItemsArrayComponent } from './components/form/perDiemOptions/perDiemoptions.component';
import { PerDiemItemControlComponent } from './components/form/perDiemItems/perDiem-item-control.component';
import { TravelExpensesWithoutVoucherItemsArrayComponent } from './components/form/travelExpensesWithoutVoucherOptions/travelExpensesWithoutVoucheroptions.component';
import { TravelExpensesWithoutVoucherItemControlComponent } from './components/form/travelExpensesWithoutVoucherItems/travelExpensesWithoutVoucher-item-control.component';
import { TravelExpensesWithVoucherItemsArrayComponent } from './components/form/TravelExpensesWithVoucherOptions/travelExpensesWithVoucheroptions.component';
import { TravelExpensesWithVoucherItemControlComponent } from './components/form/TravelExpensesWithVoucherItems/travelExpensesWithVoucher-item-control.component';
import { OtherExpensesItemsArrayComponent } from './components/form/otherExpensesOptions/otherExpensesoptions.component';
import { OtherExpensesItemControlComponent } from './components/form/otherExpensesItems/otherExpenses-item-control.component';
import { FlightService } from './shared/services/flight.service';
import { HotelService } from './shared/services/hotel.service';
import { PassportService } from './shared/services/passport.service';
import { ForexService } from './shared/services/forex.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    LoginLayoutComponent,
    HomeLayoutComponent,
    LoginComponent,
    RequestDialog,
    TableOverviewExample,
    FlightItemsArrayComponent,
    FlightItemControlComponent,
    HotelItemsArrayComponent,
    HotelItemControlComponent,
    FareItemsArrayComponent,
    FareItemControlComponent,
    BoardingLodgingItemsArrayComponent,
    BoardingLodgingItemControlComponent,
    PerDiemItemsArrayComponent,
    PerDiemItemControlComponent,
    TravelExpensesWithoutVoucherItemsArrayComponent,
    TravelExpensesWithoutVoucherItemControlComponent,
    TravelExpensesWithVoucherItemsArrayComponent,
    TravelExpensesWithVoucherItemControlComponent,
    OtherExpensesItemsArrayComponent,
    OtherExpensesItemControlComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    RouterModule.forRoot([

      {
        path: '',
        component: HomeLayoutComponent,
        canActivate: [AuthGuard],
        children: [
          { path: '', redirectTo: 'home', pathMatch: 'full' },
          { path: 'counter', component: CounterComponent },
          { path: 'fetch-data', component: FetchDataComponent },
          { path: 'home', component: TableOverviewExample },


        ]
      },
      {
        path: '',
        component: LoginLayoutComponent,
        children: [
          {
            path: 'login',
            component: LoginComponent   // {5}
          }]
      }

    ])
  ],
  
  entryComponents: [RequestDialog],
  providers: [MediaMatcher, ConfigService, RequestService, UserService, GridService, FlightService, HotelService, PassportService, ForexService, AuthService, AuthGuard, httpInterceptorProviders,
    { provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent],

})

export class AppModule { }
