import { AppConfig } from '../../config/app.config';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SaveRoom } from '../models/room.model';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class RoomService {
    private  roomEndpoint : string =   AppConfig.endpoints.hotel.routes.rooms;
    private  configEndpoint : string = AppConfig.endpoints.hotel.routes.config;

    constructor(private http: HttpClient) {
     }


    getRoomTypes() {
        return this.http.get(this.configEndpoint+"roomtypes");
      }
    
      getRoomStages() {
        return this.http.get(this.configEndpoint+"roomstates");
      }

      getBeds() {
        return this.http.get(this.configEndpoint+"beds");
      }

      getRooms() {        
        return this.http.get<any>(this.roomEndpoint);
      }

      getRoom(id:number) {
        return this.http.get(this.roomEndpoint + id);
      }

    create(room:any){
       return this.http.post(this.roomEndpoint, room);
    }

    update(room: SaveRoom){
        return this.http.put(this.roomEndpoint + room.id, room);
     }
}