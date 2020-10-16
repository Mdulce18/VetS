import { DatePipe } from "@angular/common";

export interface Historia {
  id: number,
  mascotaId: number,
  fecha: DatePipe,
  contenido: string,
  nombreVet:string
}
