import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { PatientRoutingModule } from './patient-routing.module';


import { AddPatientComponent } from './components/add-patient/add-patient.component';
import { EditPatientComponent } from './components/edit-patient/edit-patient.component';
import { AllPatientsComponent } from './components/all-patients/all-patients.component';

import { PatientsService } from './services/patients.service';


@NgModule({
  imports: [
    PatientRoutingModule,
    CommonModule,
    FormsModule,
    CustomFormsModule
  ],
  declarations: [
    AddPatientComponent,
    EditPatientComponent,
    AllPatientsComponent
  ],
  providers:[
    PatientsService
  ]
})
export class PatientsModule { }
