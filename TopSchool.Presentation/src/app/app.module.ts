import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgModule } from '@angular/core';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';

// CUSTOM COMPONENTS
import { AlunosComponent } from './custom_components/alunos/alunos.component';
import { AlunosProfessoresComponent } from './custom_components/alunosProfessores/alunosProfessores.component';
import { ProfessoresComponent } from './custom_components/professores/professores.component';
import { PerfilComponent } from './custom_components/perfil/perfil.component';
import { DashboardsComponent } from './custom_components/dashboards/dashboards.component';
import { NavComponent } from './custom_components/shareds/nav/nav.component';
import { TitleComponent } from './custom_components/shareds/title/title.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    AlunosProfessoresComponent,
    ProfessoresComponent,
    PerfilComponent,
    DashboardsComponent,
    NavComponent,
    TitleComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDropdownModule.forRoot(),
    FormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    NgxSpinnerModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
