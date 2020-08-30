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

    this.mascotaService.getMascotas().subscribe(mascotas => this.mascotas = mascotas);
  }

  alCambiarFiltro() {

  }

}
