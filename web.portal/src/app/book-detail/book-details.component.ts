import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/service/book.services';
import { RoomService } from '../shared/service/room.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import 'moment/locale/pt-br';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: any = {};
  public flRoomEdit: boolean;
  public flEditGuest : boolean;
  public flEditBook : boolean;

  constructor(private bookService: BookService,
    private roomService: RoomService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router) {
    route.params.subscribe(p => {
      this.book.roomId = +p['roomId'];
      this.book.id = +p['bookId'];
    });
  }

  ngOnInit() {
    this.flRoomEdit = false;
    this.flEditGuest = false;
    this.flEditBook = true;
    this.getBook();
  }

  private getBook() {
    this.bookService.getBook(this.book.id)
      .subscribe((res) => {
        this.book = res;
        this.book.checkIn = moment(this.book.checkIn).format('DD/MM/YYYY HH:MM:SS');
        this.book.checkOut = moment(this.book.checkOut).format('DD/MM/YYYY HH:MM:SS');
      });
  }

  enableDisableRoomEdit(flShow: boolean) {   
    this.flRoomEdit = flShow;
  }

  hideRoomEdit(room: any){
    if(room)  
      this.book.room = room;
      
    this.flRoomEdit = false;
  }

  newDayRoom(){
    this.bookService.createDayRoom(this.book.id)
          .subscribe(res => {
            this.toastr.success('Nova diária criada.', 'Sucesso!'); 
            this.book = res;
            this.book.checkIn = moment(this.book.checkIn).format('DD/MM/YYYY HH:MM:SS');
            this.book.checkOut = moment(this.book.checkOut).format('DD/MM/YYYY HH:MM:SS');
          })
  }



}
