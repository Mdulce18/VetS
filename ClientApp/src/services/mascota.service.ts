import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MascotaService {

  constructor(private http: HttpClient) {

  }

  getAnimales() {
    return this.http.get('/api/animales');
  }

  createMascota(mascota) {
    return this.http.post('/api/mascotas', mascota);
  }

  getMascota(id) {
    return this.http.get('/api/mascotas/' + id);
  }

  updateMascota(mascota) {
    return this.http.put('/api/mascotas/' + mascota.id, mascota);
  }

  deleteMascota(id) {
    return this.http.delete('/api/mascotas/' + id);
  }
}
