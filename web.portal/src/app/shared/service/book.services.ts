
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../config/app.config';



@Injectable({ providedIn: 'root' })
export class BookService {  
    private  bookEndpoint =   AppConfig.endpoints.hotel.routes.books;
    private  guestEndpoint = AppConfig.endpoints.hotel.routes.guests;
 
    constructor(private http: HttpClient) { }

    create(book:any){
        return this.http.post(this.bookEndpoint, book);
         
     }

     createDayRoom(bookId:number){
        return this.http.get(this.bookEndpoint + bookId +"/dayroom");
     }
     
     getBook(bookId:number){
         return this.http.get(this.bookEndpoint + bookId);
     }

     searchGuest(cpf:string){
        return this.http.get(this.guestEndpoint + cpf);
     }
 
}