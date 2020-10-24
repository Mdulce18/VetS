import { Component, OnInit } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { MascotaService } from '../../services/mascota.service';
import { HistoriaClinicaService } from '../../services/historiaClinica.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-historia-clinica-view',
    templateUrl: './historia-clinica-view.component.html',
    styleUrls: ['./historia-clinica-view.component.css']
})
/** historia-clinica-view component*/
export class HistoriaClinicaViewComponent implements OnInit {
/** historia-clinica-view ctor */

  mascota: any;
  mascotaId: number;
  historiaId: number;
  historia: any;
  public Editor = ClassicEditor;
  public isDisabled = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private mascotaService: MascotaService,
    private historiaService: HistoriaClinicaService
  ) {
    route.params.subscribe(p => {
      this.historiaId = +p['id']
    })
      }

   ngOnInit() {
     this.historiaService.getHistoria(this.historiaId).subscribe(res => {
       this.historia = res;
       this.mascotaId = this.historia.mascotaId;
       this.mascotaService.getMascota(this.mascotaId).subscribe(mascota => this.mascota = mascota);
     });
     
  }
}
