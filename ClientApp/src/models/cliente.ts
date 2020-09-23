import { Contacto } from "./contacto";
import { KeyValuePair } from "./keyValuePair";

export interface Cliente {
  id: number;
  contacto: Contacto;
  DNI: string;
  mascotaId: number;
  clienteMascota: KeyValuePair [];
}
