export class PerDiemItem {

    constructor(perDiemItem: IPerDiemItem = {
        arrivalDate: "",
        departureDate: "",
        currency: "",
        eligibility: 0,
        totalDays: 0,
        totalAmount: 0,
        remarks: "",
        reimbursementInfoId: 0,
    }) {
        this.arrivalDate = perDiemItem.arrivalDate;
        this.departureDate = perDiemItem.departureDate;
        this.currency = perDiemItem.currency;
        this.eligibility = perDiemItem.eligibility;
        this.totalDays = perDiemItem.totalDays;
        this.totalAmount = perDiemItem.totalAmount;
        this.remarks = perDiemItem.remarks;
        this.reimbursementInfoId = perDiemItem.reimbursementInfoId;
        
    }
    public arrivalDate: string;
    public departureDate: string;
    public currency: string;
    public eligibility: number;
    public totalDays: number;
    public totalAmount: number;
    public remarks: string;
    public reimbursementInfoId: number;
}


export interface IPerDiemItem {
    arrivalDate: string;
    departureDate: string;
    currency: string;
    eligibility: number;
    totalDays: number;
    totalAmount: number;
    remarks: string;
    reimbursementInfoId: number;
    
}