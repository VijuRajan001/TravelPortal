
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { Injectable } from '@angular/core';
import { MatInputModule,MatFormFieldModule,MatButtonModule} from '@angular/material';


@Component({
    selector: 'boardingLodging-item-control',
    templateUrl:'./boardingLodging-item-control.component.html'
        
})
@Injectable()
export class BoardingLodgingItemControlComponent {

    @Input()
    public index: number;

    @Input()
    public boardingLodgingItem: FormGroup;

    @Output()
    public removed: EventEmitter<number> = new EventEmitter<number>();

    @Output()
    public add: EventEmitter<number> = new EventEmitter<number>();;
 

    static buildItemwithValue(data: any) {

        return new FormGroup({
            'placeOfStay': new FormControl(data.placeOfStay),
            'fromDate': new FormControl(data.fromDate, Validators.required),
            'toDate': new FormControl(data.toDate, Validators.required),
            'currency': new FormControl(data.currency, Validators.required),
            'amountSpent': new FormControl(data.amountSpent, Validators.required),
            'eligibility': new FormControl(data.eligibility, Validators.required),
            'remarks': new FormControl(data.remarks, Validators.required),

        });
    }


    static buildItem(val: string) {
        return new FormGroup({
            'id': new FormControl(),
            'hotelName': new FormControl(val, Validators.required),
            'location': new FormControl(val, Validators.required),
            'website': new FormControl(val, Validators.required),
            'mobileno': new FormControl(val, Validators.required)
        })
    }
}
