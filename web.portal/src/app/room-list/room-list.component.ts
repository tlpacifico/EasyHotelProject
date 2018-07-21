
import { Component, OnInit } from '@angular/core';
import { RoomService } from '../shared/service/room.service';
import { faUserCheck,  faEdit, faUserEdit} from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-room-list',
    templateUrl: 'room-list.component.html'
})

export class RoomListComponent implements OnInit {
    columns = [       
        { title: 'Apto'},
        { title: 'Andar'},
        { title: 'Tipo'},
        { title: 'Situação'},
        { title: 'Camas'},
        { title: 'Qtd. Hósp'},
        { title: 'Entrada'},
        { title: 'Saída'},
        { title: 'Hóspedes'},
        {}
      ];
      rooms:any = [];
      faUserCheck = faUserCheck;
      faEdit = faEdit;
      faUserEdit= faUserEdit;

    constructor(
        private roomService: RoomService,
      ) { 
      
      }

    ngOnInit() { 
        this.roomService.getRooms().subscribe(res =>{
            this.rooms = res;
        })
     }
}