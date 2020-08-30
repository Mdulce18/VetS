import { KeyValuePair } from "./keyValuePair";

export interface Mascota {
  id: number;
  nombre: string;
  animal: KeyValuePair;
  raza: KeyValuePair;
  fechaNacimiento: string;
  actualizacion: string;
}
