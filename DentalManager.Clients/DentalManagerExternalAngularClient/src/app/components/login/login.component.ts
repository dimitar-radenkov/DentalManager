import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { LoginModel } from '../../models/LoginModel';

import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  model: LoginModel

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastService: ToastrService,
    private ngxService: NgxUiLoaderService) {
       this.model = new LoginModel("", "");
      }

  ngOnInit() {
  }

  ngOnDestroy() {
    
  }

  onLogin(){
    this.ngxService.start();

    this.authService
      .login(this.model)
      .subscribe(
        data => { 
          console.log(data); 
          this.ngxService.stop();
          this.authService.token = data["token"]; 
          this.toastService.success(`Wellcome ${this.model.username}`);
          this.router.navigate([""]);
        }, 
        err => { 
          this.ngxService.stop();
          this.toastService.error(err["error"]);
        }
      );
  }
}
