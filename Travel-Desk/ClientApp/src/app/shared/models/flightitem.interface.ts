export class FlightItem {

    constructor(flightItem: IFlightItem = {
        id: 0,
        flightItemId:"",
        flightName:"",
        flightFrom: "",
        flightTo: "",
        requestInfoId: 0,
        flightDirection: ""
    })
    {
        this.id = flightItem.id;
        this.flightItemId = flightItem.flightItemId;
        this.flightName = flightItem.flightName;
        this.flightFrom = flightItem.flightFrom;
        this.flightTo = flightItem.flightTo;
        this.requestInfoId = flightItem.requestInfoId;
        this.flightDirection = flightItem.flightDirection;
    }
    public id:number
    public flightItemId: string;
    public flightName: string;  
    public flightFrom: string;
    public flightTo: string;
    public requestInfoId: number;
    public flightDirection: string;
}

export interface IFlightItem {
    id: number;
    flightItemId: string;
    flightName: string;
    flightFrom: string;
    flightTo: string;
    requestInfoId: number;
    flightDirection: string;
}