import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from './../../shared/service/book.services';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RoomService } from '../../shared/service/room.service';


@Component({
    selector: 'room-edit',
    templateUrl: 'room-edit.component.html'
})

export class RoomEditComponent implements OnInit {

    @Output() public roomEdit = new EventEmitter<any>();
    public rooms: any;
    private readonly PAGE_SIZE = 30;
    private roomSelected: number;
    private bookId: number;
    queryResult: any = {};
    query: any = {
        pageSize: this.PAGE_SIZE,
        isSortAscending: true,
        sortBy: 'doorNumber',
        roomStateId: 1
    };
    constructor(private roomService: RoomService,
        private bookService: BookService,
        private toastr: ToastrService,
        private route: ActivatedRoute) 
        {
        route.params.subscribe(p => {
            this.bookId = +p['bookId'];
        });
    }

    ngOnInit() {

        this.roomService.getRooms(this.query)
            .subscribe(result => this.queryResult = result)

    }

    hideRoomEdit(room: any) {
        this.roomEdit.emit(room);
    }

    save() {
        var room = this.queryResult.items.find(m => m.id == this.roomSelected);
        this.bookService.changeRoom(this.bookId, this.roomSelected)
        .subscribe(res => {
            this.toastr.success('Quarto alterado.', 'Sucesso!'); 
            this.hideRoomEdit(room);         
        })
      
    }


}