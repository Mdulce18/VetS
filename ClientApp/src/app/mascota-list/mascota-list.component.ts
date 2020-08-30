import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';
import { Mascota } from '../../models/mascota';
import { KeyValuePair } from '../../models/keyValuePair';

@Component({
  selector: 'app-mascota-list',
  templateUrl: './mascota-list.component.html',
  styleUrls: ['./mascota-list.component.css']
})
/** mascota-list component*/
export class MascotaListComponent implements OnInit {
  mascotas: any = [];
  animales: any = [];
  filtro: any = {};

  constructor(private mascotaService: MascotaService) { }

  ngOnInit() {
    this.mascotaService.getAnimales().subscribe(animales => this.animales = animales);

    this.llenarConMascotas();
  }

  private llenarConMascotas() {
    this.mascotaService.getMascotas(this.filtro).subscribe(mascotas => this.mascotas = mascotas);
  }

  alCambiarFiltro() {
    this.llenarConMascotas();
  }

  sortBy(nombreColumna) {
    if (this.filtro.sortBy === nombreColumna) {
      this.filtro.isSortAscending = false;
    } else {
      this.filtro.sortBy = nombreColumna;
      this.filtro.isSortAscendig = true;
    }

    this.llenarConMascotas();
  }

}
