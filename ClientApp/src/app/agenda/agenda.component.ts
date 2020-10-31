import { Component, ViewChild, OnInit } from '@angular/core';
import { CalendarOptions, FullCalendarComponent } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import timeGridPlugin from '@fullcalendar/timegrid';
import esLocale from '@fullcalendar/core/locales/es';
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

  constructor(private turnoService: TurnoService) { }

  ngOnInit() {
    this.turnoService.getTunos().subscribe(eventModel => {
      this.eventsModel = eventModel;
      console.log("Eventos: ", this.eventsModel);
      for (var e of this.eventsModel) {
        this.eventFC.push({title: e.observaciones, start: e.dia })
      };
      console.log("EFC: ", this.eventFC);
    });
    this.calendarOptions = {
      plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
      editable: true,
      //eventSources: 
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
  }
  
  handleDateClick(arg) {
    console.log(arg);
  }

  handleEventClick(arg) {
    console.log(arg);
  }

  handleEventDragStop(arg) {
    console.log(arg);
  }

}
