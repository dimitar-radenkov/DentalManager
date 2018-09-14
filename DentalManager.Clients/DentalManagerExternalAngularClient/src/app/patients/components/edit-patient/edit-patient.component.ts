import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { EditPatientModel } from '../../models/EditPatientModel';
import { PatientsService } from '../../services/patients.service';

import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css']
})
export class EditPatientComponent implements OnInit {

  id: string;
  model: EditPatientModel;

  constructor(
    private activatedRoute: ActivatedRoute,
    private ngxService: NgxUiLoaderService,
    private toastService: ToastrService,
    private router: Router,
    private patientsService: PatientsService) {
    this.model = new EditPatientModel("", "", "");
  }

  ngOnInit() {
    this.activatedRoute.params
      .subscribe(
        params => {
          this.id = params["id"];
          this.patientsService
            .get(this.id)
            .subscribe(
              data => this.model = new EditPatientModel(
                data["name"],
                data["email"],
                data["phoneNumber"]),
              err => this.toastService.error(err["error"]));
        });
  }

  onUpdate() {

    this.ngxService.start();

    this.patientsService
      .edit(this.id, this.model)
      .subscribe(
        data => {
          this.toastService.success("Patient has been updated successfully");
          this.router.navigate(["patients"]);
          this.ngxService.stop();
        },
        err => this.toastService.error(err["error"]));
  }
}
