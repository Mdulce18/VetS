import { Component, OnInit } from '@angular/core';
import { MascotaService } from '../../services/mascota.service';
import { Mascota } from '../../models/mascota';

@Component({
    selector: 'app-mascota-list',
    templateUrl: './mascota-list.component.html',
    styleUrls: ['./mascota-list.component.scss']
})
/** mascota-list component*/
export class MascotaListComponent implements OnInit {
  mascotas: any =[];

  constructor(private mascotaService: MascotaService) { }

  ngOnInit() {
    this.mascotaService.getMascotas().subscribe(mascotas => this.mascotas = mascotas);
    }
}
