import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../../services/animal.service';

@Component({
    selector: 'app-mascota-form',
    templateUrl: './mascota-form.component.html',
    styleUrls: ['./mascota-form.component.css']
})
/** mascota-form component*/
export class MascotaFormComponent implements OnInit {
  animales: any;
  razas: any [];
  mascota: any = {};

  /** mascota-form ctor */
  constructor(private animalService: AnimalService) {

    }
  ngOnInit() {
    this.animalService.getAnimales().subscribe(animales => this.animales = animales);
  }
  alCambiarAnimal() {
    var animalSeleccionado = this.animales.find(a => a.id == this.mascota.animal);
    this.razas = animalSeleccionado ? animalSeleccionado.razas : [];
  }
}
