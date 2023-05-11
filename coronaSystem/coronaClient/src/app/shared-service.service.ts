import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Patient } from './patients/Patient';
import { Vaccine } from './Vaccine';
import { VaccineForPatient } from './VaccineForPatient';
@Injectable({
  providedIn: 'root'
})
export class SharedServiceService {
  baseUrl="https://localhost:7063/api";
  constructor(private http:HttpClient) { }
  GetAllUsers(){
    return this.http.get(this.baseUrl + "/Patients");
  }
  getUserById(id: number){
    return this.http.get(this.baseUrl + "/Patients/"+id);
  }
  addUser(p:Patient){
    return this.http.post(this.baseUrl + "/Patients",p);
  }
  getVaccinesForPatient(patientId: number) {
    return this.http.get(`${this.baseUrl}/VaccinesForPatients/GetAllVaccineToPatient/${patientId}`);
  }
  addVaccinesForPatient(v: VaccineForPatient) {
    return this.http.post(this.baseUrl + "/VaccinesForPatients",v);
  }
  getAllvaccinations(){
    return this.http.get(this.baseUrl + "/CoronaVaccine");
  }
  addVaccine(v:Vaccine){
    return this.http.post(this.baseUrl + "/CoronaVaccine",v);
  }
  UploadImage(formData:FormData){
    return this.http.post(this.baseUrl + "/Patients/UploadFile",formData);
  }
  getPositive(){
    return this.http.get(this.baseUrl+"/Patients/positivecases")
  }
}