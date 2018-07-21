import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RoomListComponent } from './room-list/room-list.component';
import { RoomFormComponent } from './room-form/room-form.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookDetailsComponent } from './book-detail/book-details.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'room', component: RoomListComponent },
            { path: 'room/new', component: RoomFormComponent },
            { path: 'room/:id', component: RoomFormComponent },
            { path: 'room/:id/book', component: BookFormComponent },  
            { path: 'room/:roomId/book/:bookId', component: BookDetailsComponent },               
            { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/