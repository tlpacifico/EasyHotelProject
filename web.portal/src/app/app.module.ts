import { DayRoomComponent } from './book-detail/dayroom-detail/dayroom-detail.component';

import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { TextMaskModule } from 'angular2-text-mask';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';
import { AppConfig, APP_CONFIG } from './config/app.config';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppErrorHandler } from './app.error-handler';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';
import { RoomFormComponent } from './room-form/room-form.component';
import { RoomListComponent } from './room-list/room-list.component';
import { RoomDetailComponent} from './room-detail/room-detail.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookDetailsComponent } from './book-detail/book-details.component';
import { RoomEditComponent } from './book-detail/room-edit/room-edit.component';
import { GuestListComponent } from './book-detail/guest-list/guest-list.component';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent, 
    HomeComponent,
    RoomDetailComponent,
    RoomFormComponent,
    RoomListComponent,
    BookFormComponent,
    BookDetailsComponent,
    RoomEditComponent,
    GuestListComponent,
    DayRoomComponent
  ],
  imports: [
    BrowserModule,   
    FormsModule,
    HttpClientModule,
    AppRoutingModule,  
    TextMaskModule, 
    FontAwesomeModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    NgbModule.forRoot()
  ],
  providers: [ { provide: ErrorHandler, useClass: AppErrorHandler },
               {provide: APP_CONFIG, useValue: AppConfig}],
  bootstrap: [AppComponent]
})
export class AppModule { }
