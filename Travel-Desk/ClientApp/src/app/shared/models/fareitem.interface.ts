export class FareItem {

    constructor(fareItem: IFareItem = {
        travelMode: "",
        date: "",
        from: "",
        to: "",
        currency: "",
        amountSpent: 0,
        eligibility: 0,
        remarks: "",
        reimbursementInfoId: 0,
    }) {
        this.travelMode = fareItem.travelMode;
        this.date = fareItem.date;
        this.from = fareItem.from;
        this.to = fareItem.to;
        this.currency = fareItem.currency;
        this.eligibility = fareItem.eligibility;
        this.amountSpent = fareItem.amountSpent;
        this.remarks = fareItem.remarks;
        this.reimbursementInfoId = fareItem.reimbursementInfoId;
        
    }
    public travelMode: string;
    public date: string;
    public from: string;
    public to: string;
    public currency: string;
    public amountSpent: number;
    public eligibility: number;
    public remarks: string;
    public reimbursementInfoId: number;
}


export interface IFareItem {
    travelMode: string;
    date: string;
    from: string;  
    to: string;
    currency: string;
    amountSpent: number;
    eligibility: number;
    remarks: string;
    reimbursementInfoId: number;
    
}