import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { MascotaService } from '../../services/mascota.service';
import { HistoriaClinicaService } from '../../services/historiaClinica.service';

@Component({
    selector: 'app-historia-clinica-search',
    templateUrl: './historia-clinica-search.component.html',
    styleUrls: ['./historia-clinica-search.component.css']
})
/** historiaClinica-search component*/
export class HistoriaClinicaSearchComponent implements OnInit {
/** historiaClinica-search ctor */
  mascotas: any = [];
  mascotaId: number;
  mascotaSel: any;
  registros: any = [];

  constructor(
    private mascotaService: ClienteService,
    private buscadorMascota: MascotaService,
    private historiaService: HistoriaClinicaService
  ) { }

  ngOnInit (){
    this.mascotaService.getMascotas().subscribe(mascotas => this.mascotas = mascotas);
  }

  alSeleccionarNombre() {
    console.log("Mascotas", this.mascotas);
    this.mascotaId = this.mascotaId;
    //this.buscadorMascota.getMascota(this.mascotaId).subscribe(resultado => this.mascotaSel = resultado);
    console.log("mascotaId", this.mascotaId)
  }

  buscarRegistros() {
    this.historiaService.getHistoriasMascota(this.mascotaId)
      .subscribe(registros => this.registros = registros);
    console.log("Registros", this.registros);

  }

}
