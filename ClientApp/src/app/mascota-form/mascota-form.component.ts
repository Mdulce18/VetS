import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { forkJoin } from 'rxjs';
import { SaveMascota } from '../../models/saveMascota';
import { Mascota } from '../../models/mascota';

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
  fechaNacimiento: string;
  mascota: SaveMascota = {
    id: 0,
    nombre: '',
    animalId:0,
    razaId:0,
    fechaNacimiento:'',
  }
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
    var sources = [
      this.mascotaService.getAnimales()
    ];

    if (this.mascota.id)
      sources.push(this.mascotaService.getMascota(this.mascota.id));

    forkJoin(sources)
      .subscribe(data => {
        this.animales = data[0];

        if (this.mascota.id) {
          this.setMascota(data[1]);
          this.llenarFormulario();
        }
          
    });
  }

  setMascota(m) {
    this.mascota.id = m.id;
    this.mascota.nombre = m.nombre;
    this.mascota.animalId = m.animal.id;
    this.mascota.razaId = m.raza.id;
    this.mascota.fechaNacimiento = m.fechaNacimiento;
  }

  alIngresarNombre() {
    this.mascota.nombre = this.nombre;
    
  }

  alCambiarAnimal() {
    this.llenarFormulario();
    delete this.mascota.razaId;
  }

  llenarFormulario() {
    var animalSeleccionado = this.animales.find(a => a.id == this.mascota.animalId );
    this.razas = animalSeleccionado ? animalSeleccionado.razas : [];
  }

  alSelFNacimiento() {
    this.mascota.fechaNacimiento = this.fechaNacimiento;

  }

  guardar() {
    this.mascota.animalId = Number(this.mascota.animalId);
    this.mascota.razaId = Number(this.mascota.razaId);

    if (this.mascota.id) {
      this.mascotaService.updateMascota(this.mascota)
        .subscribe(x => this.tostrService.success('Se actualizo los datos de la mascota', 'Mensaje:'));
    }
    else {
      this.mascotaService.createMascota(this.mascota)
        .subscribe(x => this.tostrService.success('Se ha dado de alta una nueva mascota', 'Mensaje:'))
    }

    
  }

  borrar() {
    if (confirm("Estas seguro de borrar esta mascota?")) {
      this.mascotaService.deleteMascota(this.mascota.id)
        .subscribe(x => {
          this.router.navigate(['/']);
        });
    }
  }

}
