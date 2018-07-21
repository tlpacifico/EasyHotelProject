import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { BookService } from '../shared/service/book.services';
import { RoomService } from '../shared/service/room.service';


@Component({
    selector: 'app-book-form',
    templateUrl: 'book-form.component.html',
    styleUrls: ['./book-form.component.css']
})

export class BookFormComponent implements OnInit {
    public maskCpf = [/[0-9]/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];
    public maskPhone = ['(', /[1-9]/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
    public maskCep = [/[0-9]/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/];
    public maskDateTime = [/\d/, /\d/, '/', /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, ':', /\d/, /\d/]
    book: any = {
        id: 0,
        guests: [],
        newGuests: [],
        checkOut: ''
    };
    guests: any = [];
    room: any = {}
    guest: any = {
        endereco: {}
    };
    constructor(
        private bookService: BookService,
        private roomService: RoomService,
        private toastr: ToastrService,
        private route: ActivatedRoute,
        private router: Router) {

        route.params.subscribe(p => {
            this.room.id = +p['id'];
        });
    }

    ngOnInit() {
        this.book.roomId = this.room.id;
        this.roomService
            .getRoom(this.room.id).subscribe(data => {
                this.room = data
            });
    }
    focusOutSearchGuest() {
        if (this.guest.cpf) {
            this.guest.cpf = this.guest.cpf.replace(/\D+/g, '');
            this.bookService.searchGuest(this.guest.cpf)
                .subscribe(data => {
                    if (data)
                        this.guest = data
                });
        }
    }

    addGuest() {
        this.guest.fone = this.guest.fone.replace(/\D+/g, '');
        this.guest.endereco.cep = this.guest.endereco.cep.replace(/\D+/g, '');
        this.guests.push(this.guest);
        this.guest = { endereco: {} };

    }

    submit() {
        if (this.book.checkOut)
            this.book.checkOut = this.book.checkOut.replace(/\D+/g, '')

        if (this.book.id) {

        }
        else {
            this.book.guests = [];
            this.book.newGuests = [];
            this.guests.forEach(guest => {
                if (guest.id)
                    this.book.guests.push(guest.id);
                else
                    this.book.newGuests.push(guest);
            });
            this.bookService.create(this.book)
                .subscribe(res => {
                    this.toastr.success('Check-In cadastro.', 'Sucesso!');
                    this.router.navigate(['/room']);
                })
        }

    }
}