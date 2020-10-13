import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HistoriaClinicaService {
  constructor(private http: HttpClient) {

  }

  createHistoria(historia) {
    return this.http.post('/api/historias', historia);
  }

  getHistoria(id) {
    return this.http.get('api/historias/' + id);
  }

  getHistoriasMascota(id) {
    return this.http.get('api/historias/mascota/' + id);
  }
}
