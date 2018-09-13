import { HomeComponent } from "../components/home/home.component";
import { LoginComponent } from "../components/login/login.component";

import { AllPatientsComponent } from "../components/patients/all-patients/all-patients.component";
import { AddPatientComponent } from "../components/patients/add-patient/add-patient.component";
import { EditPatientComponent } from "../components/patients/edit-patient/edit-patient.component";
import { AuthGuard } from "../guards/auth.guard";

export const AppRoutes = [
    { path: '', component: HomeComponent },

    { path: 'login', component: LoginComponent }, 
    
    { path: 'patients', component: AllPatientsComponent, canActivate: [AuthGuard] },
    { path: 'patients/add', component: AddPatientComponent, canActivate: [AuthGuard] },
    { path: 'patients/edit/:id', component: EditPatientComponent,  canActivate: [AuthGuard] },
];

