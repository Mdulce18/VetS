import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { MascotaService } from '../../services/mascota.service';
import { HistoriaClinicaService } from '../../services/historiaClinica.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-historia-clinica',
  templateUrl: './historia-clinica.component.html',
  styleUrls: ['./historia-clinica.component.css']
})
/** historia-clinica component*/
export class HistoriaClinicaComponent {
/** historia-clinica ctor */
  mascotaId: number;
  contenido: string;
  htmlContent: string;
  nombreVet: string;
  mascotas: any = [];
  mascotaSel: any;
  historia: any = {
  mascotaId: 0,
  contenido: '',
  nombreVet: ''
}

  constructor(
            private mascotaService: ClienteService,
            private buscadormascota: MascotaService,
            private historiaClinica: HistoriaClinicaService,
            private tostrService: ToastrService,) { }

  ngOnInit() {
    this.mascotaService.getMascotas().subscribe(mascotas => this.mascotas = mascotas);

    console.log("Mascotas", this.mascotas);
  }

  alSeleccionarNombre() {
    this.historia.mascotaId = Number(this.mascotaId);
    console.log("MascotaId", this.mascotaId);
    this.buscadormascota.getMascota(this.mascotaId).subscribe(resultado => this.mascotaSel = resultado);
    console.log("MascotaSeleccionada", this.mascotaSel)
  }

  registro(event) {
    this.contenido = event.getData();
    this.historia.contenido = this.contenido;
    console.log(event.getData());
    console.log("Contenido", this.contenido)
  }
  nombreVeterinario() {
    this.historia.nombreVet = this.nombreVet;
  }
  guardar() {
    this.historiaClinica.createHistoria(this.historia)
      .subscribe(x => this.tostrService.success('Añadido un nuevo registro a la historia clínica de la mascota', 'Mensaje:'))
  }
}
