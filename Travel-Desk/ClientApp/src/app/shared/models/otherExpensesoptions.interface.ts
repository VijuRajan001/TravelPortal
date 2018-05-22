import { OtherExpensesItem } from './otherExpensesitem.interface';


export class OtherExpensesOptions {

    constructor(otherExpensesOptions: IOtherExpensesOptions = {

        otherExpensesItems: new Array<OtherExpensesItem>(),
        

    }) {

        this.OtherExpensesItems = otherExpensesOptions.otherExpensesItems;
       

    }
    public OtherExpensesItems: OtherExpensesItem[];
   
}


export interface IOtherExpensesOptions {
    otherExpensesItems: OtherExpensesItem[]
}