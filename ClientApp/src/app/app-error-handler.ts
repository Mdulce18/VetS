import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastrService } from "ngx-toastr";


export class AppErrorHandler implements ErrorHandler {

  constructor(
    private ngZone: NgZone,
    @Inject(ToastrService) private tostrService: ToastrService) { }

  handleError(error: any): void {
    this.ngZone.run(() => {

      if (error.status === 400)
        this.tostrService.error('Hubo un problema con la solicitud!', 'Mensaje:')
      if (error.status === 404)
        this.tostrService.error('No hay una mascota con ese ID !', 'Mensaje:')
    });

  };


}
