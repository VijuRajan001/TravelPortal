export class TravelExpensesWithoutVoucherItem {

  constructor(travelExpensesWithoutVoucherItem: ITravelExpensesWithoutVoucherItem = {
        id:0,
        date: "",
        from: "",
        to: "",
        modeOfConveyance: "",
        currency: "",
        amountSpent: 0,
        remarks: "",
        reimbursementInfoId: 0,
  }) {
    this.id = travelExpensesWithoutVoucherItem.id;
        this.date = travelExpensesWithoutVoucherItem.date;
        this.from = travelExpensesWithoutVoucherItem.from;
        this.to = travelExpensesWithoutVoucherItem.to;
        this.modeOfConveyance = travelExpensesWithoutVoucherItem.modeOfConveyance;
        this.currency = travelExpensesWithoutVoucherItem.currency;
        this.amountSpent = travelExpensesWithoutVoucherItem.amountSpent;
        this.remarks = travelExpensesWithoutVoucherItem.remarks;
        this.reimbursementInfoId = travelExpensesWithoutVoucherItem.reimbursementInfoId;
        
  }
  public id: number;
  public date: string;
    public from: string;
    public to: string;
    public modeOfConveyance: string;
    public currency: string;
    public amountSpent: number;
    public remarks: string;
    public reimbursementInfoId: number;
}


export interface ITravelExpensesWithoutVoucherItem {
  id: number;
  date: string;
    from: string;
    to: string;
    modeOfConveyance: string;
    currency: string;
    amountSpent: number;
    remarks: string;
    reimbursementInfoId: number;
    
}
