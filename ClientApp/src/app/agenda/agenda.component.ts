import { Component, ViewChild, OnInit } from '@angular/core';
import { CalendarOptions, FullCalendarComponent } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import timeGridPlugin from '@fullcalendar/timegrid';
import esLocale from '@fullcalendar/core/locales/es';
import { Router } from '@angular/router';
import { TurnoService } from '../../services/turno.service';

@Component({
    selector: 'app-agenda',
    templateUrl: './agenda.component.html',
    styleUrls: ['./agenda.component.css']
})
/** agenda component*/
export class AgendaComponent implements OnInit {

  calendarOptions: CalendarOptions;
  eventsModel: any = [];
  eventFC: any = [];

  @ViewChild('fullcalendar', { static: false }) fullcalendar: FullCalendarComponent;

  constructor(private turnoService: TurnoService, private router: Router,) { }

  ngOnInit() {
    this.turnoService.getTunos().subscribe(eventModel => {
      this.eventsModel = eventModel;
      console.log("Eventos: ", this.eventsModel);
      for (var e of this.eventsModel) {
        this.eventFC.push({ id:e.id, start: e.dia, title: e.observaciones, editable: false })
      };
      console.log("EFC: ", this.eventFC);
      this.calendarOptions = {
        plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
        slotMinTime: "08:00:00",
        slotMaxTime: "20:00:00",
        editable: true,
        events: this.eventFC,
        //locale: esLocale,
        headerToolbar: {
          left: 'prev,next today',
          center: 'title',
          right: 'timeGridDay timeGridWeek dayGridMonth'
        },
        dateClick: this.handleDateClick.bind(this),
        eventClick: this.handleEventClick.bind(this),
        eventDragStop: this.handleEventDragStop.bind(this)
      };
    });
  }
  
  handleDateClick(arg) {
    console.log(arg);
  }

  handleEventClick(arg) {
    console.log(arg);
    if (confirm("quiere modificar los datos del turno?")) {
      this.router.navigate(['/turnos/' + arg.event._def.publicId]);
        };
    //$("#eventoBackdrop").modal("show");
  }

  handleEventDragStop(arg) {
    console.log(arg);
  }

}
