import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TurnoService {
  constructor(private http: HttpClient) {

  }

  getTunos() {
    return this.http.get('/api/turnos/todos');
  }

  getTiposTurnos() {
    return this.http.get('/api/turnos/tipos');
  }

  getTurno(id) {
    return this.http.get('/api/turnos/' + id);
  }

  createTurno(turno) {
    return this.http.post('/api/turnos', turno);
  }

  updateTurno(turno) {
    return this.http.put('/api/turnos' + turno.id, turno);
  }

  deleteTurno(id) {
    return this.http.delete('/api/turnos' + id);
  }
}
