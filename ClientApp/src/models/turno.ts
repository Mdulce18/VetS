import { Cliente } from "./cliente";

export interface Turno {
  id: number;
  clienteId: number;
  dia: string;
  horario: string;
  tipoTurnoId: number;
  observaciones: string;
}
