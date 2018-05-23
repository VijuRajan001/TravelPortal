export class BoardingLodgingItem {

    constructor(boardingLodgingItem: IBoardingLodgingItem = {
        id:0,
        placeOfStay: "",
        fromDate: "",
        toDate: "",
        currency: "",
        amountSpent: 0,
        remarks: "",
        reimbursementInfoId: 0,
    }) {
        this.id = boardingLodgingItem.id;
        this.placeOfStay =boardingLodgingItem.placeOfStay;
        this.fromDate = boardingLodgingItem.fromDate;
        this.toDate = boardingLodgingItem.toDate;
        this.currency = boardingLodgingItem.currency;
        this.amountSpent = boardingLodgingItem.amountSpent;
        this.remarks = boardingLodgingItem.remarks;
        this.reimbursementInfoId = boardingLodgingItem.reimbursementInfoId;
        
  }
    public id:number
    public placeOfStay: string;
    public fromDate: string;
    public toDate: string;
    public currency: string;
    public amountSpent: number;
        public remarks: string;
    public reimbursementInfoId: number;
}


export interface IBoardingLodgingItem {
    id:number
    placeOfStay: string;
    fromDate: string;
    toDate: string;
    currency: string;
    amountSpent: number;
    remarks: string;
    reimbursementInfoId: number;
}
