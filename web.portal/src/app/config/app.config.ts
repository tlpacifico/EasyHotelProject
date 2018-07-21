import { InjectionToken } from '@angular/core';

import { IAppConfig } from './iapp.config';

export let APP_CONFIG = new InjectionToken('app.config');

export const AppConfig: IAppConfig = {
  endpoints: {
    hotel: {
      url: 'http://localhost:5000/api/',
      routes:{
        books: 'http://localhost:5000/api/' + 'books/',
        rooms:'http://localhost:5000/api/' + 'rooms/',
        guests: 'http://localhost:5000/api/' + 'guests/',
        config: 'http://localhost:5000/api/' + 'config/'
      }
    }
  }
};