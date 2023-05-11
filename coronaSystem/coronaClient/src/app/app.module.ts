import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PatientsComponent } from './patients/patients.component';
import { ShowPatientsComponent } from './patients/show-patients/show-patients.component';
import { AddPatientsComponent } from './patients/add-patients/add-patients.component';
import { SharedServiceService } from './shared-service.service';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { VaccinationsComponent } from './vaccinations/vaccinations.component';
import { ShowVaccinationsComponent } from './vaccinations/show-vaccinations/show-vaccinations.component';
import { AddVaccinationsComponent } from './vaccinations/add-vaccinations/add-vaccinations.component';
import { GraphComponent } from './graph/graph.component';

@NgModule({
  declarations: [
    AppComponent,
    PatientsComponent,
    ShowPatientsComponent,
    AddPatientsComponent,
    VaccinationsComponent,
    ShowVaccinationsComponent,
    AddVaccinationsComponent,
    GraphComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,
    AppRoutingModule,FormsModule,ReactiveFormsModule,
  ],
  providers: [SharedServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
