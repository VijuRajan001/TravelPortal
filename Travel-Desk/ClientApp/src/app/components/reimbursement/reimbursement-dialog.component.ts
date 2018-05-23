import { ActivatedRoute, Params } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { Directive, Attribute } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog,MatAccordion ,MatDialogRef, MAT_DIALOG_DATA,MatExpansionModule,MatTableModule,MatDividerModule } from '@angular/material';
import { Inject } from '@angular/core';
import { TravelData, ITravelData } from '../../shared/models/traveldata.interface';
import { FormGroup, FormControl, Validators, FormGroupDirective, NgForm, FormArray, FormBuilder, NG_VALIDATORS, } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ReimbursementService } from '../../shared/services/reimbursement.service'
import { FareService } from '../../shared/services/fareinfo.service';
import { PerDiemService } from '../../shared/services/perDiemInfo.service';
import { BoardingLodgingService } from '../../shared/services/boardingLodging.service';
import { TravelExpensesWithVoucherService } from '../../shared/services/travelExpensesWithVoucher.service';
import { TravelExpensesWithoutVoucherService } from '../../shared/services/travelExpensesWithoutVoucher.service';
import { OtherExpensesService } from '../../shared/services/otherExpenses.service';
import { AuthService } from '../../shared/services/auth.service';
import { forkJoin } from "rxjs/observable/forkJoin";
import { MatTabChangeEvent } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { ReimbursementData, IReimbursementData } from '../../shared/models/reimbursementdata.interface';
import { AbstractControl } from '@angular/forms/src/model';
import { Request } from '@angular/http/src/static_request';
import { ViewChild } from '@angular/core/src/metadata/di';
import { AppComponent } from '../app/app.component';
import { RequestDialog } from '../request/request-dialog.component';
import { FareItemsArrayComponent } from '../form/fareOptions/fareoptions.component';
import { PerDiemItemsArrayComponent } from '../form/perDiemOptions/perDiemoptions.component';
import { BoardingLodgingItemsArrayComponent } from '../form/boardingLodgingOptions/boardingLodgingoptions.component';
import { TravelExpensesWithoutVoucherItemsArrayComponent } from '../form/TravelExpensesWithoutVoucherOptions/travelExpensesWithoutVoucheroptions.component';
import { TravelExpensesWithVoucherItemsArrayComponent } from '../form/TravelExpensesWithVoucherOptions/travelExpensesWithVoucheroptions.component';
import { OtherExpensesItemsArrayComponent } from '../form/otherExpensesOptions/otherExpensesoptions.component';
import { RequestData, IRequestData } from '../../shared/models/requestdata.interface';
import { FlightItem, IFlightItem } from '../../shared/models/flightitem.interface';
import { HotelOptions, IHotelOptions } from '../../shared/models/hoteloptions.interface';
import { HotelService } from '../../shared/services/hotel.service';
import { Passport, IPassport } from '../../shared/models/passport.interface';
import { PassportService } from '../../shared/services/passport.service';
import { ForexCard, IForexCard } from '../../shared/models/forex.interface';
import { ForexService } from '../../shared/services/forex.service';
import { FlightOptions, IFlightOptions } from '../../shared/models/flightoptions.interface';
import { FlightService } from '../../shared/services/flight.service';
import { IHotelItem, HotelItem } from '../../shared/models/hotelitem.interface';
import { FareOptions, IFareOptions } from '../../shared/models/fareoptions.interface';
import { BoardingLodgingOptions, IBoardingLodgingOptions } from '../../shared/models/boardingLodgingoptions.interface';
@Component({
    selector: 'reimbursement-dialog',
    templateUrl: './reimbursement-dialog.component.html',
    styleUrls: ['./reimbursement-dialog.component.css'],

})

export class ReimbursementDialog implements OnInit, Validators {

  today = new Date();
  maxDate = new Date(this.today.getFullYear() - 18, this.today.getMonth(), this.today.getDate());
  mindate = new Date(this.today);
  minDate1 = new Date(this.today.getFullYear(), this.today.getMonth(), this.today.getDate());

    step = 0;


    traveldata: TravelData = new TravelData();
    submitActions: number;
    action: typeof SubmitActionsReimburseMent = SubmitActionsReimburseMent;
    matcher = new MyErrorStateMatcher();
    ReimbursementForm: FormGroup;
    FareOptionsForm: FormGroup;
    PerDiemForm: FormGroup;
    BoardingExpensesForm: FormGroup;
    ForexForm: FormGroup;
    TravelWithVoucherForm: FormGroup;
    TravelWithoutVoucherForm: FormGroup;
    OtherExpensesForm: FormGroup;


    constructor(@Inject(MAT_DIALOG_DATA) public data: any,
        public dialogRef: MatDialogRef<RequestDialog>, private reimbursementService: ReimbursementService,
        private fareService: FareService,
        private perDiemService: PerDiemService,
        private boardingLodgingService: BoardingLodgingService,
        private travelExpensesWithVoucherService: TravelExpensesWithVoucherService,
        private travelExpensesWithoutVoucherService: TravelExpensesWithoutVoucherService,
        private otherExpensesService:OtherExpensesService,
        private fb: FormBuilder,
        private formBuilder: FormBuilder) {

        //data = 0 means new request
        console.log(data);


    }

    resetExpansionPanel(val:number) {

        this.step = val;

    }

  
    getFareOptionsFormArray() {
        return (this.FareOptionsForm.get('fareItems') as FormArray);
    }

   

    onNoClick(): void {
        this.dialogRef.close();
    }



    ngOnInit(): void {

        this.ReimbursementForm = this.fb.group({

            
            'employeeId': new FormControl(null, [Validators.required]),
            'employeeName': new FormControl(null, [Validators.required]),
            'designation': new FormControl(null, [Validators.required]),
            'band': new FormControl(null, [Validators.required]),
            'clientName': new FormControl(null, [Validators.required, Validators.maxLength(50)]),
            'projectCode': new FormControl(null, [Validators.required]),
            'costCenter': new FormControl(null, [Validators.required]),
            'purposeOfTravel': new FormControl(null, [Validators.required]),
            'locationOfTravel': new FormControl(null, [Validators.required]),
            'arrivalDate': new FormControl(null, [Validators.required, Validators.maxLength(50)]),
            'departureDate': new FormControl(null, [Validators.required]),
            'travelBillable': new FormControl(null, [Validators.required]),
            'flightReimbursable': new FormControl(null, [Validators.required]),
            'travelReimbursable': new FormControl(null, [Validators.required, Validators.maxLength(50)]),
            'otherReimbursable': new FormControl(null, [Validators.required]),
        

            });



        this.FareOptionsForm = this.fb.group({

            'fareItems': FareItemsArrayComponent.buildItems(),
            

        });

        this.PerDiemForm = this.fb.group({
            'perDiemItems': PerDiemItemsArrayComponent.buildItems()
        });

        this.BoardingExpensesForm = this.fb.group({
            'lodgingItems': BoardingLodgingItemsArrayComponent.buildItems()         
        });

        this.TravelWithVoucherForm = this.fb.group({
            'voucherItems': TravelExpensesWithVoucherItemsArrayComponent.buildItems()
           
        });
        this.TravelWithoutVoucherForm = this.fb.group({
            'nonVoucherItems': TravelExpensesWithoutVoucherItemsArrayComponent.buildItems()
           
        });

        this.OtherExpensesForm = this.fb.group({
            'otherExpenseItems': OtherExpensesItemsArrayComponent.buildItems()
           
        });

        if (this.data > 0) {
          let reimbursementData = this.reimbursementService.getReimbursementById(this.data);
          let fareData = this.fareService.getFareForRequest(this.data);
          let perDiemData = this.perDiemService.getPerDiemForRequest(this.data);
          let boardingData = this.boardingLodgingService.getBoardingLodgingForRequest(this.data);
          let voucherData = this.travelExpensesWithVoucherService.getTravelExpensesWithVoucherForRequest(this.data);
          let nonVoucher =  this.travelExpensesWithoutVoucherService.getTravelExpensesWithoutVoucherForRequest(this.data);
          let otherExpenseData = this.otherExpensesService.getOtherExpensesForRequest(this.data);
           forkJoin([reimbursementData, fareData, perDiemData, boardingData, voucherData,nonVoucher,otherExpenseData], ).subscribe(results => {

                this.ReimbursementForm.patchValue(new ReimbursementData(<IReimbursementData>results[0]));
        //        this.PassportForm.patchValue(new Passport(<IPassport>results[3]));
        //        this.ForexForm.patchValue(new ForexCard(<IForexCard>results[4]))
        //        let flightOptions = new FlightOptions(<IFlightOptions>results[1]);
        //        let hotelOptions = new HotelOptions(<IHotelOptions>results[2]);


        //        let i = 0;
        //        flightOptions.OnwardFlightItems.forEach(item => {
        //            if (i == 0) {
        //                this.getOnwardFormArray().setControl(i, FlightItemsArrayComponent.buildItemsWithValue(item));
        //            } else {
        //                this.getOnwardFormArray().insert(i, FlightItemsArrayComponent.buildItemsWithValue(item));
        //            }
        //            i = i + 1;
        //        });
        //        i = 0;
        //        flightOptions.ReturnFlightItems.forEach(item => {
        //            if (i == 0) {
        //                this.getReturnFormArray().setControl(i, FlightItemsArrayComponent.buildItemsWithValue(item));
        //            } else {
        //                this.getReturnFormArray().insert(i, FlightItemsArrayComponent.buildItemsWithValue(item));
        //            }
        //            i = i + 1;
        //        });
        //        i = 0;
        //        hotelOptions.HotelItems.forEach(item => {
        //            if (i == 0) {
        //                this.getHotelFormArray().setControl(i, HotelItemsArrayComponent.buildItemsWithValue(item));
        //            } else {
        //                this.getHotelFormArray().insert(i, HotelItemsArrayComponent.buildItemsWithValue(item));
        //            }
        //            i = i + 1;


        //        });


        //        this.traveldata.requestData = new RequestData(<IRequestData>this.ReimbursementDataForm.value);
        //        this.traveldata.flightData = new FlightOptions(<IFlightOptions>this.FlightOptionsForm.value);
        //        this.traveldata.hotelData = new HotelOptions(<IHotelOptions>this.HotelOptionsForm.value);
        //        this.traveldata.passportData = new Passport(<IPassport>this.PassportForm.value);
        //        this.traveldata.forexCardData = new ForexCard(<IForexCard>this.ForexForm.value);




            });

        }
    }




   

    setStep(index: number) {
        this.step = index;

    }

    nextStep() {
    
        this.step++;
  
    }

    prevStep() {
       
        this.step--;
        
    }

    onSubmit() {

        console.log(this.submitActions);
        switch (this.submitActions) {

            case SubmitActionsReimburseMent.createUpdateReimbursement: this.createUpdateReimbursement(); break;
            case SubmitActionsReimburseMent.createUpdateFare: this.createUpdateFare(); break;
            case SubmitActionsReimburseMent.createUpdateBoarding: this.createUpdateBoarding(); break;
            //case SubmitActions.createPassport: this.createPassport(); break;
            //case SubmitActions.createForex: this.createForex(); break;
        }

    }




    createUpdateFare() {
        let savefaredata: FareOptions;
        let addfaredata: FareOptions = new FareOptions();
        let updateFlightdata: FareOptions = new FareOptions();


        if (this.FareOptionsForm.valid) {


            savefaredata = new FareOptions(<IFareOptions>this.FareOptionsForm.value);
            //this.deleteFare(savefaredata);
            savefaredata.FareItems.forEach(item => {
                item.reimbursementInfoId = this.data;
                
                if (item.id === null) {
                    item.id = 0;
                    addfaredata.FareItems.push(item);

                }
                else {

                    updateFlightdata.FareItems.push(item);
                }

            });

            console.log(addfaredata);
            savefaredata.FareItems.forEach(item => {
                item.reimbursementInfoId = this.data;
               
                if (item.id === null) {
                    item.id = 0;
                    addfaredata.FareItems.push(item);
                }
                else {

                    updateFlightdata.FareItems.push(item);
                }
            });


            this.fareService.addFareInfo(addfaredata).subscribe(
                (val) => {
                    console.log("POST call success");
                },
                response => {
                    console.log("POST call in error", response);
                },
                () => {
                    console.log("The POST observable is now completed.");
                });

            //this.fareService.updateFareInfo(updateFlightdata).subscribe(
            //    (val) => {
            //        console.log("POST call success");
            //    },
            //    response => {
            //        console.log("POST call in error", response);
            //    },
            //    () => {
            //        console.log("The POST observable is now completed.");
            //    });
        }


    }

    //deleteFare(fareOptions: fareOptions) {
    //    let initialfareOptions: fareOptions = this.traveldata.flightData;
    //    let deletedItemsId: number[] = [];

    //    if (initialFlightOPtions.OnwardFlightItems.length > finalFlightOPtions.OnwardFlightItems.length
    //        || initialFlightOPtions.ReturnFlightItems.length > finalFlightOPtions.ReturnFlightItems.length) {

    //        initialFlightOPtions.OnwardFlightItems.forEach(item => {
    //            let index = finalFlightOPtions.OnwardFlightItems.findIndex((flightItem: FlightItem) => { return item.id == flightItem.id })

    //            if (index === -1) {
    //                deletedItemsId.push(item.id);
    //            }
    //        });

    //    }

    //    if (deletedItemsId.length > 0) {
    //        this.flightService.deleteflights(deletedItemsId).subscribe(
    //            (val) => {
    //                console.log("POST call success");
    //            },
    //            response => {
    //                console.log("POST call in error", response);
    //            },
    //            () => {
    //                console.log("The POST observable is now completed.");
    //            });
    //    }



    //}
    createUpdateBoarding() {

        let saveBoardingdata: BoardingLodgingOptions;
        let addBoardingdata: BoardingLodgingOptions = new BoardingLodgingOptions();
        let updateBoardingdata: BoardingLodgingOptions = new BoardingLodgingOptions();

        if (this.BoardingExpensesForm.valid) {

            saveBoardingdata = new BoardingLodgingOptions(<IBoardingLodgingOptions>this.BoardingExpensesForm.value);
            //this.deleteHotelOptions(saveHoteldata);
            saveBoardingdata.BoardingLodgingItems.forEach(item => {
                item.reimbursementInfoId = this.data;

                if (item.id === null || item.id === 0) {
                    item.id = 0;
                    addBoardingdata.BoardingLodgingItems.push(item);

                }
                else {

                    updateBoardingdata.BoardingLodgingItems.push(item);
                }

            });

            this.boardingLodgingService.addBoardingLodgingInfo(addBoardingdata).subscribe(
                (val) => {
                    console.log("POST call success");
                },
                response => {
                    console.log("POST call in error", response);
                },
                () => {
                    console.log("The POST observable is now completed.");
                });



            //this.boardingLodgingService.updateBoardingLodgingInfo(updateBoardingdata).subscribe(
            //    (val) => {
            //        console.log("POST call success");
            //    },
            //    response => {
            //        console.log("POST call in error", response);
            //    },
            //    () => {
            //        console.log("The POST observable is now completed.");
            //    });



        }


    }

    //deleteHotelOptions(finalHotelOptions: HotelOptions) {
    //    let initialHotelOptions: HotelOptions = this.traveldata.hotelData;
    //    let deletedItemsId: number[] = [];

    //    if (initialHotelOptions.HotelItems.length > finalHotelOptions.HotelItems.length) {

    //        initialHotelOptions.HotelItems.forEach(item => {
    //            let index = finalHotelOptions.HotelItems.findIndex((hotelItem: HotelItem) => { return item.id == hotelItem.id })

    //            if (index === -1) {
    //                deletedItemsId.push(item.id);
    //            }
    //        });

    //    }

    //    if (deletedItemsId.length > 0) {
    //        this.hotelService.deleteHotels(deletedItemsId).subscribe(
    //            (val) => {
    //                console.log("POST call success");
    //            },
    //            response => {
    //                console.log("POST call in error", response);
    //            },
    //            () => {
    //                console.log("The POST observable is now completed.");
    //            });
    //    }


    //}


    //createPassport() {
    //    if (this.PassportForm.valid) {
    //        let passportdata: Passport = new Passport(<IPassport>this.PassportForm.value);

    //        if (passportdata.id == 0 || passportdata.id == null) {

    //            passportdata.requestInfoId = this.data;
    //            this.passportService.addPassportInfo(passportdata).subscribe(
    //                (val) => {
    //                    console.log("POST call success");
    //                },
    //                response => {
    //                    console.log("POST call in error", response);
    //                },
    //                () => {
    //                    console.log("The POST observable is now completed.");
    //                });

    //        }
    //        else {
    //            this.passportService.updatePassportInfo(passportdata).subscribe(
    //                (val) => {
    //                    console.log("POST call success");
    //                },
    //                response => {
    //                    console.log("POST call in error", response);
    //                },
    //                () => {
    //                    console.log("The POST observable is now completed.");
    //                });

    //        }

    //    }


    //}


    //createForex() {
    //    if (this.ForexForm.valid) {

    //        let forexdata = new ForexCard(<IForexCard>this.ForexForm.value);

    //        if (forexdata.id == 0 || forexdata.id == null) {
    //            forexdata.requestInfoId = this.data;
    //            this.forexService.addForexInfo(forexdata).subscribe(
    //                (val) => {
    //                    console.log("POST call success");
    //                },
    //                response => {
    //                    console.log("POST call in error", response);
    //                },
    //                () => {
    //                    console.log("The POST observable is now completed.");
    //                });

    //        }
    //        else {
    //            this.forexService.updateForexInfo(forexdata).subscribe(
    //                (val) => {
    //                    console.log("POST call success");
    //                },
    //                response => {
    //                    console.log("POST call in error", response);
    //                },
    //                () => {
    //                    console.log("The POST observable is now completed.");
    //                });

    //        }
    //    }
    //}

  

    //updateRequest() {

    //    let requestdata: RequestData;
    //    if (this.ReimbursementDataForm.valid) {

    //        requestdata = new RequestData();
    //        requestdata.requestId = this.data;
    //        requestdata.project_code = this.ReimbursementDataForm.controls['project_Code'].value;
    //        requestdata.country = this.ReimbursementDataForm.controls['country'].value;
    //        requestdata.travelDate = this.ReimbursementDataForm.controls['travelDate'].value;
    //        requestdata.returnDate = this.ReimbursementDataForm.controls['returnDate'].value;
    //        requestdata.employeeId = this.ReimbursementDataForm.controls['employeeId'].value;
    //        requestdata.employeeName = this.ReimbursementDataForm.controls['employeeName'].value;
    //        this.requestService.updateRequest(requestdata).subscribe(
    //            (val) => {
    //                console.log("POST call success");
    //            },
    //            response => {
    //                console.log("POST call in error", response);
    //            },
    //            () => {
    //                console.log("The POST observable is now completed.");
    //            });


    //    }

    //}

    createUpdateReimbursement() {
        let reimbursementData: ReimbursementData;
        if (this.ReimbursementForm.valid) {
            reimbursementData = new ReimbursementData();
            
            reimbursementData.employeeId = this.ReimbursementForm.controls['employeeId'].value;
            reimbursementData.employeeName = this.ReimbursementForm.controls['employeeName'].value;
            reimbursementData.designation = this.ReimbursementForm.controls['designation'].value;
            reimbursementData.bandWorkLevel = this.ReimbursementForm.controls['band'].value;
            reimbursementData.clientName = this.ReimbursementForm.controls['clientName'].value;
            reimbursementData.costCenter = this.ReimbursementForm.controls['costCenter'].value;
            reimbursementData.purposeOfTravel = this.ReimbursementForm.controls['purposeOfTravel'].value;
            reimbursementData.locationOfTravel = this.ReimbursementForm.controls['locationOfTravel'].value;
            reimbursementData.dateOfArrival = this.ReimbursementForm.controls['arrivalDate'].value;
            reimbursementData.dateOfDeparture = this.ReimbursementForm.controls['departureDate'].value;
            reimbursementData.travelBillableToCustomer = this.ReimbursementForm.controls['travelBillable'].value =='Yes'?true:false;
            reimbursementData.flightChargesReimbursed = this.ReimbursementForm.controls['flightReimbursable'].value=='Yes'?true:false;
            reimbursementData.travelExpenseReimbursed= this.ReimbursementForm.controls['travelReimbursable'].value=='Yes'?true:false;
            reimbursementData.anyOtherExpenseReimbursed = this.ReimbursementForm.controls['otherReimbursable'].value=='Yes'?true:false;

            
        
            this.reimbursementService.addReimbursement(reimbursementData).subscribe(
                (val) => {
                    console.log("POST call success");
                },
                response => {
                    console.log("POST call in error", response);
                },
                () => {
                    console.log("The POST observable is now completed.");
                });

        }
    }

    isOnward(c: FormControl) {
        
           
        return null;
     
    }
}  
enum SubmitActionsReimburseMent {
    createUpdateReimbursement,
    createUpdateFare,
    createUpdatePerDiem,
    createUpdateBoarding,
    createUpdatereVoucherItems,
    createUpdatereNonVoucherItems,
    createUpdatereOtherExpenses,
    
}




export class MyErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
        const isSubmitted = form && form.submitted;
        return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
    }
}
