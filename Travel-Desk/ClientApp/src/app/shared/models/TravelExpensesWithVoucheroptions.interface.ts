import { TravelExpensesWithVoucherItem } from './travelExpensesWithVoucheritem.interface';


export class TravelExpensesWithVoucherOptions {

    constructor(travelExpensesWithVoucherOptions: ITravelExpensesWithVoucherOptions = {

      voucherItems: new Array<TravelExpensesWithVoucherItem>(),
        

    }) {

      this.TravelExpensesWithVoucherItems = travelExpensesWithVoucherOptions.voucherItems;
       

    }
    public TravelExpensesWithVoucherItems: TravelExpensesWithVoucherItem[];
   
}


export interface ITravelExpensesWithVoucherOptions {
  voucherItems: TravelExpensesWithVoucherItem[]
}
