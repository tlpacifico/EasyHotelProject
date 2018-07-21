import { Component } from '@angular/core';
import { faHome, faHotel } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Easy Hotel Project';
  faHome = faHome;
  faHotel = faHotel;

}
