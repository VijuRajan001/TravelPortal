export class BoardingLodgingItem {

    constructor(boardingLodgingItem: IBoardingLodgingItem = {
        placeOfStay: "",
        fromDate: "",
        toDate: "",
        currency: "",
        amountSpent: 0,
        eligibility: 0,
        remarks: "",
        reimbursementInfoId: 0,
    }) {
        this.placeOfStay =boardingLodgingItem.placeOfStay;
        this.fromDate = boardingLodgingItem.fromDate;
        this.toDate = boardingLodgingItem.toDate;
        this.currency = boardingLodgingItem.currency;
        this.amountSpent = boardingLodgingItem.amountSpent;
        this.eligibility = boardingLodgingItem.eligibility;
        this.remarks = boardingLodgingItem.remarks;
        this.reimbursementInfoId = boardingLodgingItem.reimbursementInfoId;
        
    }
    public placeOfStay: string;
    public fromDate: string;
    public toDate: string;
    public currency: string;
    public amountSpent: number;
    public eligibility: number;
    public remarks: string;
    public reimbursementInfoId: number;
}


export interface IBoardingLodgingItem {
    placeOfStay: string;
    fromDate: string;
    toDate: string;
    currency: string;
    amountSpent: number;
    eligibility: number;
    remarks: string;
    reimbursementInfoId: number;
}