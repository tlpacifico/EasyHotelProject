import { RoomBed } from "./bed.model";

export interface SaveRoom{
    id: number; 
    doorNumber: number | undefined ;
    floorNumber: number | undefined;
    roomDescription: string | undefined;
    roomTypeId: number;
    roomStateId: number;
    beds : RoomBed[]
  }
