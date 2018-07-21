import { Component, OnInit, Input, Output,EventEmitter  } from '@angular/core';


@Component({
    selector: 'room-edit',
    templateUrl: 'room-edit.component.html'
})

export class RoomEditComponent implements OnInit {
    @Input() public room: any;
    @Output() public flRoomEdit = new EventEmitter<boolean>();
    public rooms : any;
    constructor() { }

    ngOnInit() {
        if (!this.room) 
             throw new Error('Missing room data!'); 
                
        this.rooms = [{id:1, doorNumber:"001"},{id:2, doorNumber:"101"},{id:3, doorNumber:"104"},{id:6, doorNumber:"119"}]   
      }

      enableDisableRoomEdit(){
          this.flRoomEdit.emit(false);
      }

   
}