import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';

@Component({
    selector: 'app-mascota-form',
    templateUrl: './mascota-form.component.html',
    styleUrls: ['./mascota-form.component.css']
})
/** mascota-form component*/
export class MascotaFormComponent implements OnInit {
  nombre: any;
  animales: any;
  razas: any;
  fechaNacimiento: Date;
  mascota: any = {}
  ;

  /** mascota-form ctor */
  constructor(private mascotaService: MascotaService) {

  }

  ngOnInit() {
    this.mascotaService.getAnimales().subscribe(animales => this.animales = animales);
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
    this.mascotaService.createMascota(this.mascota)
      .subscribe(x => console.log(x));
  }


}
