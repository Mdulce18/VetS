import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { Cliente } from '../../models/cliente';
import { ToastrService } from 'ngx-toastr';
import { MascotaService } from '../../services/mascota.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { KeyValuePair } from '../../models/keyValuePair';

@Component({
    selector: 'app-cliente-form',
    templateUrl: './cliente-form.component.html',
    styleUrls: ['./cliente-form.component.css']
})
/** cliente-form component*/
export class ClienteFormComponent implements OnInit{
  nombre: string;
  apellido: string;
  telefono: string;
  direccion: string;
  email: string;
  DNI: string;
  mascotaId: number;
  filtro: any;
  clientes: any = [];
  mascotas: any = [];
  cm: KeyValuePair = {
    id: 0,
    nombre:''
  }
  cliente: Cliente = {
    id: 0,
    contacto: {
      nombre: '',
      apellido: '',
      telefono: '',
      direccion: '',
      email: '',
    },
    DNI: '',
    mascotaId: 0,
    clienteMascota: []
  }
  /** cliente-form ctor */
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clienteService: ClienteService,
    private tostrService: ToastrService,
    private mascotaService: MascotaService) {

      route.params.subscribe(p => {
      this.cliente.id = +p['id']
    });

  }

  ngOnInit() {
    var sources = [
      this.clienteService.getMascotas()
    ];

      if (this.cliente.id)
      sources.push(this.clienteService.getCliente(this.cliente.id));

    forkJoin(sources)
      .subscribe(data => {
        this.mascotas = data[0];

        if (this.cliente.id)
          this.setCliente(data[1])
      });

  }

  setCliente(c) {
    this.cliente.id = c.id;
    this.cliente.contacto.nombre = c.contacto.nombre;
    this.cliente.contacto.apellido = c.contacto.apellido;
    this.cliente.contacto.telefono = c.contacto.telefono;
    this.cliente.contacto.direccion = c.contacto.direccion;
    this.cliente.contacto.email = c.contacto.email;
    this.cliente.DNI = c.dni;
    this.cliente.mascotaId = c.mascotaId;
    this.cliente.clienteMascota =c.mascotas
  }

  alSeleccionarNombre() {
    this.cliente.contacto.nombre = this.nombre;
  }
  alSeleccionarApellido() {
    this.cliente.contacto.apellido = this.apellido;
  }
  alSeleccionarTelefono() {
    this.cliente.contacto.telefono = this.telefono;
  }
  alSeleccionarDireccion() {
    this.cliente.contacto.direccion = this.direccion;
  }
  alSeleccionarEmail() {
    this.cliente.contacto.email = this.email;
  }
  alSeleccionarDNI() {
    this.cliente.DNI = this.DNI;
  }
  alSelecionarMascota() {
    this.cliente.mascotaId = +this.mascotaId;
    console.log("MascotaID", this.cliente.mascotaId);
    console.log("Mascota", this.cm.id = this.cliente.mascotaId);
  }
  guardar() {
    //console.log("cliente", this.cliente);
    if (this.cliente.id > 0)
      this.clienteService.updateCliente(this.cliente)
        .subscribe(x => this.tostrService.success('se ha actualizado los datos del Cliente', 'Mensaje:'))
    else
    this.clienteService.createCliente(this.cliente)
      .subscribe(x => this.tostrService.success('se ha dado de alta un nuevo Cliente', 'Mensaje:'));
  }

  borrar() {
    
    this.clienteService.deleteCliente(this.cliente.id).subscribe(x => {
      this.tostrService.warning('Se ha borrado de la base de datos el cliente', 'Mensaje:')
      this.router.navigate(['/']);
    });
  
    }
}
