import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
    selector: 'app-mascota-form',
    templateUrl: './mascota-form.component.html',
    styleUrls: ['./mascota-form.component.css']
})
/** mascota-form component*/
export class MascotaFormComponent implements OnInit {
  nombre: string;
  animales: any;
  razas: any = [];
  fechaNacimiento: Date;
  mascota: any = {}
  ;

  /** mascota-form ctor */
  constructor(
      private route: ActivatedRoute,
      private router: Router,
      private tostrService: ToastrService,
      private mascotaService: MascotaService) {

          route.params.subscribe(p => {
          this.mascota.id = +p['id'];
        });
      
  }

  ngOnInit() {
    this.mascotaService.getAnimales().subscribe(animales => this.animales = animales);


    this.mascotaService.getMascota(this.mascota.id)
        .subscribe(m => { this.mascota = m; });
  }

  alIngresarNombre() {
    this.mascota.nombre = this.nombre;
    
  }

  alCambiarAnimal() {
    var animalSeleccionado = this.animales.find(a => a.id == this.mascota.animalId);
    this.razas = animalSeleccionado ? animalSeleccionado.razas : [];
    delete this.mascota.razaId;
    
  }

  alSelFNacimiento() {
    this.mascota.fechaNacimiento = this.fechaNacimiento;

  }

  Guardar() {
    this.mascota.animalId = Number(this.mascota.animalId);
    this.mascota.razaId = Number(this.mascota.razaId);

    this.mascotaService.createMascota(this.mascota)
      .subscribe(x => console.log(x),
        (error: Response) => {
          if (error.status === 400)
            this.tostrService.error('Hubo un problema con la solicitud!', 'Mensaje:')
          if (error.status === 404)
            this.tostrService.error('No hay una mascota con ese ID !', 'Mensaje:')
        },
        () =>this.tostrService.success('Mascota Creada!', 'Mensaje:'))
  }


}
