import { BoardingLodgingItem} from './boardingLodgingitem.interface';


export class BoardingLodgingOptions {

    constructor(boardingLodgingOptions: IBoardingLodgingOptions = {

        lodgingItems: new Array<BoardingLodgingItem>(),
        

    }) {

        this.BoardingLodgingItems = boardingLodgingOptions.lodgingItems;
       

    }
    public BoardingLodgingItems: BoardingLodgingItem[];
   
}


export interface IBoardingLodgingOptions {
    lodgingItems: BoardingLodgingItem[]
}
