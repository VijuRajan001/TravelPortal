import { TravelExpensesWithoutVoucherItem } from './travelExpensesWithoutVoucheritem.interface';


export class TravelExpensesWithoutVoucherOptions {

    constructor(travelExpensesWithoutVoucherOptions: ITravelExpensesWithoutVoucherOptions = {

      nonVoucherItems: new Array<TravelExpensesWithoutVoucherItem>(),
        

    }) {

      this.TravelExpensesWithoutVoucherItems = travelExpensesWithoutVoucherOptions.nonVoucherItems;
       

    }
    public TravelExpensesWithoutVoucherItems: TravelExpensesWithoutVoucherItem[];
   
}


export interface ITravelExpensesWithoutVoucherOptions {
  nonVoucherItems: TravelExpensesWithoutVoucherItem[]
}
