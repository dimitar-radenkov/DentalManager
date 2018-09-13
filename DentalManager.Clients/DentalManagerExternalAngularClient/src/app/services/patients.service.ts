import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AppSettings } from '../app.settings';
import { AddPatientModel } from '../models/AddPatientModel';
import { EditPatientModel } from '../models/EditPatientModel';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {

  constructor(private http: HttpClient) { }

  getAll(){
    return this.http.get(
      AppSettings.ALL_PATIENTS_ENDPOINT);
  }

  add(patient : AddPatientModel){
    return this.http.post(
      AppSettings.ADD_PATIENT_ENDPOINT,      
      JSON.stringify(patient));
  }

  get(id){
    return this.http.get(
      `${AppSettings.GET_PATIENT_ENDPOINT}/${id}`); 
  }

  edit(id, model: EditPatientModel){
    return this.http.post(
      `${AppSettings.EDIT_PATIENT_ENDPOINT}/${id}`,     
      JSON.stringify(model));
  }

  delete(id){
    return this.http.delete(
      `${AppSettings.DELETE_PATIENT_ENDPOINT}/${id}`);
  }


  private createHeaders(){
    return new HttpHeaders(
      { 
        "Content-Type" : "application/json",
        "Authorization" : "Bearer " + localStorage.getItem(AppSettings.AUTH_KEY),
      });
  }
}
