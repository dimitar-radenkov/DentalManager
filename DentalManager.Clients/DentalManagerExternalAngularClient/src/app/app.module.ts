import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule }   from '@angular/forms';

import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';

import { CustomFormsModule } from 'ng2-validation'
import { ToastrModule } from 'ngx-toastr';
import { NgxUiLoaderModule } from  'ngx-ui-loader';

import { AuthService } from './services/auth.service';

import { AppRoutes } from './routes/AppRoutes';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    RouterModule.forRoot(AppRoutes),
    ToastrModule.forRoot({
      timeOut: 10000,
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
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
