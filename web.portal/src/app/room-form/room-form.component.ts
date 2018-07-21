
import {forkJoin as observableForkJoin} from 'rxjs';

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomService } from '../shared/service/room.service';
import { SaveRoom } from '../shared/models/room.model';
import { RoomBed } from '../shared/models/bed.model';



@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {

  constructor(
    private roomService: RoomService,
    private route: ActivatedRoute,
    private router: Router) {

    route.params.subscribe(p => {
      this.room.id = +p['id'];
    });
  }

  room: SaveRoom = {
    id: 0,
    doorNumber: undefined,
    floorNumber: undefined,
    roomDescription: undefined,
    roomTypeId: 0,
    roomStateId: 0,
    beds: []
  };
  roomTypes: any = [];
  roomStates: any = [];
  beds: any = [];
  bedsInitial: any[] = [];
  selectedBed: any = {};
  selectedBeds: any[] = [];
  ngOnInit() {
    var sources = [
      this.roomService.getRoomTypes(),
      this.roomService.getRoomStages(),
      this.roomService.getBeds()
    ];

    if (this.room.id) {
      sources.push(this.roomService.getRoom(this.room.id));

    }

    observableForkJoin(sources).subscribe(data => {
      this.roomTypes = data[0];
      this.roomStates = data[1];
      this.beds = data[2];
      this.bedsInitial = Object.assign([], this.beds);;

      if (this.room.id) {      
        this.setRoom(data[3]);
      }
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
  }

  setRoom(roomRaw: any) {
    this.room.id = roomRaw.id;
    this.room.doorNumber = roomRaw.doorNumber;
    this.room.floorNumber = roomRaw.floorNumber;
    this.room.roomDescription = roomRaw.roomDescription;
    this.room.roomStateId = roomRaw.roomState.id;
    this.room.roomTypeId = roomRaw.roomType.id;

    roomRaw.beds.forEach((bed: any) => {   
      this.addBedtoRoom(bed.bedId, bed.numberBeds);
    });

  }

  addBedtoRoom(bedId: number, numberBeds:number) {

    var bed = this.beds.find(m => m.id == bedId);   
    var bedRoom : RoomBed = { bedId : bed.id,  name : bed.name,  numberBeds : numberBeds   };

    this.room.beds.push(bedRoom);
    this.selectedBeds.push(bedRoom);
    this.selectedBed = {};

    var index = this.beds.indexOf(bed);
    this.beds.splice(index, 1);
  }

  resertBeds() {
    this.selectedBeds = [];
    this.room.beds = [];
    this.beds = this.bedsInitial;
  }

  submit(f: any) {
    if (this.room.id) {
      this.roomService.update(this.room)
        .subscribe(x => {
        
        });
    }
    else {
      this.room.id = 0;
      this.roomService.create(this.room)
        .subscribe(x => {
        
          this.room = {
            id: 0,
            doorNumber: 0,
            floorNumber: 0,
            roomDescription: "",
            roomTypeId: 0,
            roomStateId: 0,
            beds: []
          };
          this.resertBeds();
          f.reset();
        });

    }
  }

}
