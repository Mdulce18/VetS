import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) {

  }

  getClientes() {
    return this.http.get('api/clientes');
  }

  createCliente(cliente) {
    return this.http.post('/api/clientes', cliente);
  }

  getCliente(id) {
    return this.http.get('/api/clientes/' + id)
  }

  updateCliente(cliente) {
    return this.http.put('/api/clientes/' + cliente.id, cliente);
  }
  deleteCliente(id) {
    return this.http.delete('/api/clientes/' + id);
  }

  getMascotas() {
    return this.http.get('/api/mascotas');
  }
}
