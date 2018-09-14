import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PatientsService } from '../../services/patients.service';
import { AddPatientModel } from '../../models/AddPatientModel';

import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {

  model: AddPatientModel;

  constructor(
    private patientsService: PatientsService,
    private toastService: ToastrService,
    private router: Router,
    private ngxService: NgxUiLoaderService) { 
    this.model = new AddPatientModel("", "", "");
  }

  ngOnInit() {

  }

  onAdd() {
    this.ngxService.start();

    this.patientsService
      .add(this.model)
      .subscribe(data => {
        console.log(data);
        this.toastService.success("Patient has been added succesfully");
        this.ngxService.stop();
        this.router.navigate(["/patients"]);
        },
        err => { 
          console.log(err) ; 
          this.toastService.error(err["error"]) 
        });

        this.ngxService.stop();
  }
}
