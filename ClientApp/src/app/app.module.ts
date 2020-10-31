import { BrowserModule } from '@angular/platform-browser';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular'
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import listPlugin from '@fullcalendar/interaction';
import timegridPlugin from '@fullcalendar/interaction';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { MascotaFormComponent } from './mascota-form/mascota-form.component';
import { MascotaService } from '../services/mascota.service';
import { AppErrorHandler } from './app-error-handler';
import { MascotaListComponent } from './mascota-list/mascota-list.component';
import { PaginationComponent } from './shared/pagination.component';
import { ClienteService } from '../services/cliente.service';
import { ClienteFormComponent } from './cliente-form/cliente-form.component';
import { ClienteListComponent } from './cliente-list/cliente-list.component';
import { HistoriaClinicaComponent } from './historia-clinica/historia-clinica.component';
import { HistoriaClinicaService } from '../services/historiaClinica.service';
import { HistoriaClinicaSearchComponent } from './historia-clinica-search/historia-clinica-search.component';
import { HistoriaClinicaViewComponent } from './historia-clinica-view/historia-clinica-view.component';
import { AgendaComponent } from './agenda/agenda.component';
import { TurnoService } from '../services/turno.service';
import { TurnoFormComponent } from './turno-form/turno-form.component';

FullCalendarModule.registerPlugins([
  dayGridPlugin,
  interactionPlugin,
  listPlugin,
  timegridPlugin
])

@NgModule({
  declarations: [
    AgendaComponent,
    AppComponent,
    ClienteFormComponent,
    ClienteListComponent,
    HistoriaClinicaComponent,
    HistoriaClinicaSearchComponent,
    HistoriaClinicaViewComponent,
    HomeComponent,
    NavMenuComponent,
    MascotaFormComponent,
    MascotaListComponent,
    PaginationComponent,
    TurnoFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CKEditorModule,
    HttpClientModule,
    FormsModule,
    FullCalendarModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'mascotas', pathMatch: 'full' },
      { path: 'agenda', component: AgendaComponent },
      { path: 'busquedas', component: HistoriaClinicaSearchComponent },
      { path: 'clientes', component: ClienteListComponent},
      { path: 'clientes/new', component: ClienteFormComponent},
      { path: 'clientes/:id', component: ClienteFormComponent },
      { path: 'historias', component: HistoriaClinicaComponent },
      { path: 'historias/:id', component: HistoriaClinicaViewComponent },
      { path: 'home', component: HomeComponent },
      { path: 'mascotas', component: MascotaListComponent },
      { path: 'mascotas/new', component: MascotaFormComponent },
      { path: 'mascotas/:id', component: MascotaFormComponent },
      { path: 'turnos', component: TurnoFormComponent },
      { path: 'turnos/new', component: TurnoFormComponent },
      { path: 'turnos/:id', component: TurnoFormComponent },
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      closeButton: true,
      positionClass: 'toast-top-right'
    }), 
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    MascotaService,
    ClienteService,
    HistoriaClinicaService,
    TurnoService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
