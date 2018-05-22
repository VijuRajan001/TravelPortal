
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { Injectable } from '@angular/core';
import { MatInputModule,MatFormFieldModule,MatButtonModule} from '@angular/material';
import { FlightItem } from '../../../shared/models/flightitem.interface';


@Component({
    selector: 'flight-item-control',
    templateUrl:'./flight-item-control.component.html'
    
})
@Injectable()
export class FlightItemControlComponent {

    @Input()
    public index: number;

    @Input()
    public item: FormGroup;

    @Output()
    public removed: EventEmitter<number> = new EventEmitter<number>();

    @Output()
    public add :EventEmitter<number> = new EventEmitter<number>();;

    static buildItemwithValue(data:any) {

        return new FormGroup({
            'id':new FormControl(data.id),
            'flightName': new FormControl(data.flightName, [Validators.required]),
            'flightItemId': new FormControl(data.flightItemId, Validators.required),
            'flightFrom': new FormControl(data.flightFrom, Validators.required),
            'flightTo': new FormControl(data.flightTo, Validators.required)

        });
    }

    static buildItem() {
        return new FormGroup({
            'id': new FormControl(),
            'flightName': new FormControl('', [Validators.required]),
            'flightItemId': new FormControl('', Validators.required),
            'flightFrom': new FormControl('', Validators.required),
            'flightTo': new FormControl('', Validators.required)

            });
        
    }
}
