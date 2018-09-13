import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';

import { CustomFormsModule } from 'ng2-validation'
import { ToastrModule } from 'ngx-toastr';
import { NgxUiLoaderModule } from 'ngx-ui-loader';

import { AuthService } from './services/auth.service';

import { AppRoutes } from './routes/AppRoutes';
import { AllPatientsComponent } from './components/patients/all-patients/all-patients.component';
import { AddPatientComponent } from './components/patients/add-patient/add-patient.component';
import { EditPatientComponent } from './components/patients/edit-patient/edit-patient.component';
import { TokenInterceptor } from './interceptors/token-interceptor';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LoginComponent,
    HomeComponent,
    AllPatientsComponent,
    AddPatientComponent,
    EditPatientComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: "toast-top-right",
      progressBar: true,
      progressAnimation: "decreasing",
      closeButton: true,
    }),
    NgxUiLoaderModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    CustomFormsModule,
  ],
  providers: [AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
