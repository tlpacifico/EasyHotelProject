import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'room-detail',
    templateUrl: 'room-detail.component.html'
    
})

export class RoomDetailComponent implements OnInit {
    @Input() public room: any;
    @Input() public flEdit: boolean = false;
    @Output() public flRoomEdit = new EventEmitter<boolean>();
    constructor() { }

    ngOnInit() {
        if (!this.room) { throw new Error('Missing room data!'); }      
      }

      enableDisableRoomEdit(){
        this.flRoomEdit.emit(true);
      }

     
}