import { ToastrService } from 'ngx-toastr';
import { BookService } from './../../shared/service/book.services';
import { RoomService } from './../../shared/service/room.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'dayroom-detail',
    templateUrl: 'dayroom-detail.component.html'
})

export class DayRoomComponent implements OnInit {
    public maskDateTime = [/\d/, /\d/, '/', /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, ':', /\d/, /\d/];
    @Input() public book;
    private flEdit: boolean;
    private bookTemp: any;
    private roomSelected: number;

    private readonly PAGE_SIZE = 30;
    queryResult: any = {};
    query: any = {
        pageSize: this.PAGE_SIZE,
        isSortAscending: true,
        sortBy: 'doorNumber',
        roomStateId: 1
    };
    constructor(private roomService: RoomService,
        private bookService: BookService,
        private toastr: ToastrService, ) { }

    ngOnInit() {
        if (!this.book)
            throw new Error('Missing book data!');

        this.flEdit = true;
        this.bookTemp = {
            checkIn: this.book.checkIn,
            checkOut: this.book.checkOut,
            guestNumber: this.book.guestNumber,
            dayRooms: this.book.dayRooms,
            roomRate: this.book.roomRate,
            totalBill: this.book.totalBill,
            room: this.book.room
        };


        this.roomService.getRooms(this.query)
            .subscribe(result => this.queryResult = result)
    }

    onEdit() {
        this.flEdit = !this.flEdit;

        if (this.flEdit) {
            this.book = this.bookTemp;
        }
    }

    save() {
        if (this.book.checkOut)
            this.book.checkOut = this.book.checkOut.replace(/\D+/g, '')

        var bookUptaded = {
            roomId: this.book.room.id,
            checkOut: this.book.checkOut,
            roomRate: this.book.roomRate,
            guestNumber: this.book.guestNumber,
        };

        if (this.roomSelected)
            bookUptaded.roomId = this.roomSelected;

        this.bookService.update(this.book.id, bookUptaded)
            .subscribe(res => {
                this.toastr.success('Hospedagem alterada.', 'Sucesso!');
                this.book = res;
                this.flEdit = !this.flEdit;
            });
    }
}