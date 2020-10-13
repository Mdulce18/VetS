import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ChangeEvent } from '@ckeditor/ckeditor5-angular/ckeditor.component';
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
  public config = {
    placeholder: 'Escriba el nuevo registro de la mascota...!'
  }
  public Editor = ClassicEditor;
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
  }

  alSeleccionarNombre() {
    this.historia.mascotaId = Number(this.mascotaId);
    console.log("MascotaId", this.mascotaId);
    this.buscadormascota.getMascota(this.mascotaId).subscribe(resultado => this.mascotaSel = resultado);
    console.log("MascotaSeleccionada", this.mascotaSel)
  }

  registro({ editor }: ChangeEvent) {
    this.contenido = editor.getData();
    this.historia.contenido = this.contenido;
    console.log(editor.getData());
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
