import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from './../../shared/service/book.services';
import { Component, OnInit, Input } from '@angular/core';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'guest-list',
    templateUrl: 'guest-list.component.html'
})

export class GuestListComponent implements OnInit {
    public maskCpf = [/[0-9]/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];
    public maskPhone = ['(', /[1-9]/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
    public maskCep = [/[0-9]/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/];
    public maskDateTime = [/\d/, /\d/, '/', /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, ':', /\d/, /\d/];
    @Input() public guests;
    private flEdit: boolean;
    private book: any = {};
    private bookId: number;
    guest: any = {
        endereco: {}
    };
    faTrashAlt = faTrashAlt;
    constructor(private bookService: BookService,
        private toastr: ToastrService,
        private route: ActivatedRoute) 
        {
        route.params.subscribe(p => {
            this.bookId = +p['bookId'];
        });
    }
    ngOnInit() {
        if (!this.guests)
            throw new Error('Missing guests data!');

        this.flEdit = false;
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

    onEditGuest() {
        this.flEdit = !this.flEdit;
    }

    removeGuest(id: number) {
        var guest = this.guests.find(g => g.id == id);
        var index = this.guests.indexOf(guest);
        this.guests.splice(index, 1);
    }

    save() {
        this.book.guests = [];
        this.book.newGuests = [];
        this.guests.forEach(guest => {
            if (guest.id)
                this.book.guests.push(guest.id);
            else
                this.book.newGuests.push(guest);
        });
        this.bookService.changeGuests(this.bookId, this.book)
            .subscribe(res => {
                this.toastr.success('Hóspedes alterados.', 'Sucesso!');
                this.onEditGuest();
            })

    }
}