export class OtherExpensesItem {

    constructor(otherExpensesItem: IOtherExpensesItem = {
        date: "",
        natureOfExpenses: "",
        currency: "",
        amountSpent: 0,
        eligibility: 0,
        supportByVoucher: 0,
        reimbursementInfoId: 0,
    }) {
        this.date = otherExpensesItem.date;
        this.natureOfExpenses = otherExpensesItem.natureOfExpenses;
        this.currency = otherExpensesItem.currency;
        this.amountSpent = otherExpensesItem.amountSpent;
        this.eligibility = otherExpensesItem.eligibility;
        this.supportByVoucher = otherExpensesItem.supportByVoucher;
        this.reimbursementInfoId = otherExpensesItem.reimbursementInfoId;
        
    }
    public date: string;
    public natureOfExpenses: string;
    public currency: string;
    public amountSpent: number;
    public eligibility: number;
    public supportByVoucher: number;
    public reimbursementInfoId: number;
}


export interface IOtherExpensesItem {
    date: string;
    natureOfExpenses: string;
    currency: string;
    amountSpent: number;
    eligibility: number;
    supportByVoucher: number;
    reimbursementInfoId: number;
}