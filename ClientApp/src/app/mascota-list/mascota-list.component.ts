import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';

@Component({
  selector: 'app-mascota-list',
  templateUrl: './mascota-list.component.html',
  styleUrls: ['./mascota-list.component.css']
})
/** mascota-list component*/
export class MascotaListComponent implements OnInit {

  private readonly PAGE_SIZE = 5;
  queryResult: any = {};
  animales: any = [];
  filtro: any = {
    pageSize: this.PAGE_SIZE
  };

  constructor(private mascotaService: MascotaService) { }

  ngOnInit() {
    this.mascotaService.getAnimales().subscribe(animales => this.animales = animales);

    this.llenarConMascotas();
  }

  private llenarConMascotas() {
    this.mascotaService.getMascotas(this.filtro)
      .subscribe(result => this.queryResult = result);
  }

  alCambiarFiltro() {
    this.filtro.page = 1;
    this.llenarConMascotas();
  }

  sortBy(nombreColumna) {
    if (this.filtro.sortBy === nombreColumna) {
      this.filtro.isSortAscending = !this.filtro.isSortAscending;
    } else {
      this.filtro.sortBy = nombreColumna;
      this.filtro.isSortAscendig = true;
    }

    this.llenarConMascotas();
  }

  onPageChange(page) {
    this.filtro.page = page;
    this.llenarConMascotas();
  }

}
