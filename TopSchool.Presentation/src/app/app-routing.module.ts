import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './custom_components/alunos/alunos.component';
import { DashboardsComponent } from './custom_components/dashboards/dashboards.component';
import { PerfilComponent } from './custom_components/perfil/perfil.component';
import { ProfessoresComponent } from './custom_components/professores/professores.component';

const routes: Routes = [
  { path: 'alunos', component: AlunosComponent },
  { path: 'professores', component: ProfessoresComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: 'dashboards', component: DashboardsComponent },
  { path: '', redirectTo: 'dashboards', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboards', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
