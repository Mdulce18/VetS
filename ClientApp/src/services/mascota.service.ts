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
  getMascotas(filtro) {
    return this.http.get('/api/mascotas' + '?' + this.queryString(filtro));
  }

  queryString(obj) {
    var partes = [];
    for (var property in obj) {
      var valor = obj[property]
      if (valor != null && valor != undefined)
        partes.push(encodeURIComponent(property) + '=' + encodeURIComponent(valor));
    }

    return partes.join('&');
  }
}
