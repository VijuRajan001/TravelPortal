
export class ReimbursementData {

    constructor(request: IReimbursementData = {
        reimbursementInfoId: 0,
        employeeName: "",
        employeeId: "",
        designation: "",
        bandWorkLevel: "",
        clientName: "",
        projectCode: "",
        costCenter: "",
        purposeOfTravel: "",
        locationOfTravel: "",
        dateOfArrival: "",
        dateOfDeparture: "",
        travelBillableToCustomer: 0,
        flightChargesReimbursed: 0,
        travelExpenseReimbursed: 0,
        anyOtherExpenseReimbursed: 0
    }) {

        this.reimbursementInfoId = request.reimbursementInfoId;
        this.employeeName = request.employeeName;
        this.employeeId = request.employeeId;
        this.designation = request.designation;
        this.bandWorkLevel = request.bandWorkLevel;
        this.clientName = request.clientName;
        this.projectCode = request.projectCode;
        this.costCenter = request.costCenter;
        this.purposeOfTravel = request.purposeOfTravel;
        this.locationOfTravel = request.locationOfTravel;
        this.dateOfArrival = request.dateOfArrival;
        this.dateOfDeparture = request.dateOfDeparture;
        this.travelBillableToCustomer = request.travelBillableToCustomer;
        this.flightChargesReimbursed = request.flightChargesReimbursed;
        this.travelExpenseReimbursed = request.travelExpenseReimbursed;
        this.anyOtherExpenseReimbursed = request.anyOtherExpenseReimbursed;

    }
    public reimbursementInfoId: number;
    public employeeName: string;
    public employeeId: string;
    public designation: string;
    public bandWorkLevel: string;
    public clientName: string;
    public projectCode: string;
    public costCenter: string;
    public purposeOfTravel: string;
    public locationOfTravel: string;
    public dateOfArrival: string;
    public dateOfDeparture: string;
    public travelBillableToCustomer: number;
    public flightChargesReimbursed: number;
    public travelExpenseReimbursed: number;
    public anyOtherExpenseReimbursed: number;

}


export interface IReimbursementData {
    reimbursementInfoId: number;
    employeeName: string;
    employeeId: string;
    designation: string;
    bandWorkLevel: string;
    clientName: string;
    projectCode: string;
    costCenter: string;
    purposeOfTravel: string;
    locationOfTravel: string;
    dateOfArrival: string;
    dateOfDeparture: string;
    travelBillableToCustomer: number;
    flightChargesReimbursed: number;
    travelExpenseReimbursed: number;
    anyOtherExpenseReimbursed: number;
}
