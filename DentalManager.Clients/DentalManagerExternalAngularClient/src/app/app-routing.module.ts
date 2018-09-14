import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './auth/components/login.component';
import { AllPatientsComponent } from './patients/components/all-patients/all-patients.component';
import { AuthGuard } from './guards/auth.guard';
import { PatientsModule } from './patients/patients.module';
import { RouterModule } from '@angular/router';

const routes = [
  { path: '', component: HomeComponent },

  { path: 'login', component: LoginComponent }, 
  
  {   
      path: 'patients', 
      component: AllPatientsComponent, 
      canActivate: [AuthGuard], 
      loadChildren: () => PatientsModule
   },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  declarations: []
})
export class AppRoutingModule { }


