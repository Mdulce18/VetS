import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';

@Component({
    selector: 'app-cliente-list',
    templateUrl: './cliente-list.component.html',
    styleUrls: ['./cliente-list.component.css']
})
/** cliente-list component*/
export class ClienteListComponent implements OnInit {

  private readonly PAGE_SIZE = 5;
  queryResult: any = {};
  clientes: any = [];
  filtro: any = {
    pageSize: this.PAGE_SIZE
  };
  /** cliente-list ctor */
  constructor(private clienteService: ClienteService) {

  }

  ngOnInit() {
    this.llenarConClientes();
  }

  private llenarConClientes() {
    this.clienteService.getClientes(this.filtro)
      .subscribe(result => this.queryResult = result);
  }
  sortBy(nombreColumna) {
    if (this.filtro.sortBy === nombreColumna) {
      this.filtro.isSortAscending = !this.filtro.isSortAscending;
    } else {
      this.filtro.sortBy = nombreColumna;
      this.filtro.isSortAscendig = true;
    }

    this.llenarConClientes();
  }

  onPageChange(page) {
    this.filtro.page = page;
    this.llenarConClientes();
  }

}
