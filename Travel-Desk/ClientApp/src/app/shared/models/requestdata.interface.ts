
export class RequestData {

    constructor(request: IRequestData = {
        requestId: 0,
        project_Code: "",
        country: "",
        travelDate: "",
        returnDate: "",
        employeeName: "",
        employeeId: "",
        dob: "",
        requestStatus:"",
    }) {

        this.requestId = request.requestId;
        this.project_code = request.project_Code;
        this.requestId = request.requestId;
        this.country = request.country;
        this.travelDate = request.travelDate;
        this.returnDate = request.returnDate;
        this.employeeName = request.employeeName;
        this.employeeId = request.employeeId;
      this.dob = request.dob;
      this.requestStatus = request.requestStatus;

    }
    public requestId: number;
    public project_code: string;
    public country: string;
    public travelDate: string;
    public returnDate: string;
    public employeeName: string;
    public employeeId: string;
  public dob: string;
  public requestStatus: string;
}


export interface IRequestData {
    requestId: number;
    project_Code: string;
    country: string;
    travelDate: string;
    returnDate: string;
    employeeName: string;
    employeeId: string;
    dob: string;
    requestStatus: string;
}
