
import { ErrorHandler, Inject, NgZone, isDevMode, Injector } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export class AppErrorHandler implements ErrorHandler {
  constructor(
    @Inject(NgZone) private ngZone: NgZone,
    @Inject(Injector) private injector: Injector
  ){ }

  private get toastrService(): ToastrService {
    return this.injector.get(ToastrService);
}
  handleError(error: any): void {
    if (!isDevMode()){      
      //TODO: save this error somewhere     
      this.toastyNotification();
    }
    else{
      this.toastyNotification();
      throw error;
     
    } 
    
  }
       
  private toastyNotification() {
    this.ngZone.run(() => {
      if (typeof(window) !== 'undefined') {
        this.toastrService.error('Um erro aconteceu..', 'Tente novamente', {
          timeOut: 3000,
        });
    }
  
  });
  }
}