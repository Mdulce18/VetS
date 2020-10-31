import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TurnoService } from '../../services/turno.service';
import { ClienteService } from '../../services/cliente.service';
import { Router, ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';

@Component({
    selector: 'app-turno-form',
    templateUrl: './turno-form.component.html',
    styleUrls: ['./turno-form.component.css']
})
/** turno-form component*/
export class TurnoFormComponent implements OnInit {

  fecha: string;
  turno: any = {
    id: 0,
    clienteId: '',
    tipoTurnoId: '',
    dia: '',
    observaciones: ''
  };
  tipoTurno: any = [];
  cliente: any = [];
  observaciones: string;
    /** turno-form ctor */
  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router,
    private tostrService: ToastrService,
    private turnoService: TurnoService) {

      route.params.subscribe(p => {
        this.turno.id = +p['id']
      });
  }

  ngOnInit() {
    var sources = [
      this.turnoService.getTiposTurnos(),
      this.clienteService.getListaClientes()
    ];
      if (this.turno.id)
        sources.push(this.turnoService.getTurno(this.turno.id));

    forkJoin(sources)
      .subscribe(data => {
        this.tipoTurno = data[0];
        this.cliente = data[1];

        if (this.turno.id)
          this.setTurno(data[2])
      });

    //this.turnoService.getTiposTurnos().subscribe(tipos => {
    //  this.tipoTurno = tipos;
    //  console.log("Tipos de Turnos: ", this.tipoTurno);
    //});
    //this.clienteService.getListaClientes().subscribe(res => {
    //  this.cliente = res;
    //  console.log("Clientes: ", this.cliente);
    //});
  }

  setTurno(t) {
    this.turno.id = t.id;
    this.turno.clienteId = t.clienteId;
    this.turno.turnoId = t.tipoTurnoId;
    this.turno.dia = t.dia;
    this.turno.observaciones = t.obsevaciones
  }

  alSeleccionarfecha() {
    this.turno.dia = this.fecha;
  }

  alCambiarTipoTurno() {
    this.turno.tipoTurnoId = Number(this.turno.tipoTurnoId);
  }
  alSeleccionarCliente() {
    this.turno.clienteId = Number(this.turno.clienteId);
  }
  alingresarObservaciones() {
    this.turno.observaciones = this.observaciones;
  }

  guardar() {
    if (this.turno.id > 0)
      this.turnoService.updateTurno(this.turno)
        .subscribe(x => {
          this.tostrService.success('se ha actualizado los datos del Turno', 'Mensaje:')
          this.router.navigate(['/agenda']);
        })
    else
      this.turnoService.createTurno(this.turno)
        .subscribe(x => {
          this.tostrService.success('se ha creado un nuevo Turno', 'Mensaje:')
          this.router.navigate(['/agenda']);
        });
  }

  borrar() {
    this.turnoService.deleteTurno(this.turno.id).subscribe(x => {
      this.tostrService.warning('Se ha borrado de la base de datos el Turno', 'Mensaje:')
      this.router.navigate(['/agenda']);
    });

  }
  
}
