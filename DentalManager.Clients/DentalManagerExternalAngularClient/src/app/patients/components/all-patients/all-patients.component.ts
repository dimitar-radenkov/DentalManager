import { Component, OnInit } from '@angular/core';

import { PatientsService } from '../../services/patients.service';
import { ToastrService } from 'ngx-toastr';

import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-all-patients',
  templateUrl: './all-patients.component.html',
  styleUrls: ['./all-patients.component.css']
})
export class AllPatientsComponent implements OnInit {

  private allPatients;
  private dataReceived = false;

  constructor(
    private patientsService: PatientsService, 
    private toastService: ToastrService,
    private ngxService: NgxUiLoaderService) 
    { }

  ngOnInit() {
    this.refresh();
  }

  onDelete(id){   

    this.ngxService.start();

    this.patientsService
      .delete(id)
      .subscribe(
        data => {
          this.toastService.success("Patient has been deleted successfully");
          this.ngxService.stop();
          this.refresh();
        },
        err => {
          this.toastService.error(err["error"]);
          this.ngxService.stop();
        });
  }

  private refresh(){
    this.ngxService.start();
    this.patientsService
      .getAll()
      .subscribe(
        data => { 
          this.allPatients = data;
          this.dataReceived = true;
          this.ngxService.stop();
        }, 
        err =>{ 
           this.toastService.error(err["error"]);
           this.ngxService.stop();
        });
  }
}
