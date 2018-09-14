import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { AddPatientComponent } from './components/add-patient/add-patient.component';
import { EditPatientComponent } from './components/edit-patient/edit-patient.component';
import { AuthGuard } from '../guards/auth.guard';

const patientsRoutes : Routes = [
  { path: 'patients/add', component: AddPatientComponent, canActivate: [AuthGuard] },
  { path: 'patients/edit/:id', component: EditPatientComponent,  canActivate: [AuthGuard] },
];

@NgModule({
  imports: [
    RouterModule.forChild(patientsRoutes),
  ],
  exports:[RouterModule],
  declarations: []
})
export class PatientRoutingModule { }
