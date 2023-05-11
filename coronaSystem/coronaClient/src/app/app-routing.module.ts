import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GraphComponent } from './graph/graph.component';
import { Patient } from './patients/Patient';
import {PatientsComponent} from './patients/patients.component'
import { VaccinationsComponent } from './vaccinations/vaccinations.component';
const routes: Routes = [
  {path:'patients',component: PatientsComponent},
  {path:'vaccinations',component:VaccinationsComponent},
  {path:'graph',component:GraphComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
