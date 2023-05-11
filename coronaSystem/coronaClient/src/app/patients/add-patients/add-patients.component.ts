import { Component } from '@angular/core';
import { SharedServiceService } from 'src/app/shared-service.service';
import { VaccinationsComponent } from 'src/app/vaccinations/vaccinations.component';
import { Vaccine } from 'src/app/Vaccine';
import { VaccineForPatient } from 'src/app/VaccineForPatient';
import { Patient } from '../Patient';
import { FormGroup, FormBuilder, Validators, FormControl, NgForm } from '@angular/forms';


@Component({
  selector: 'app-add-patients',
  templateUrl: './add-patients.component.html',
  styleUrls: ['./add-patients.component.css']
})
export class AddPatientsComponent {
  p: Patient = new Patient(0, "", "", "", "", "", "", "", 0, new Date(), new Date(), new Date(),"")
  arrV: Vaccine[] = []
  arrp:Patient[]=[];
  x: number = 0
  firstHalf: boolean = true
  secondHalf: boolean = false
  PhotoFilePath: string = ""
  url:string=""
  arrVaccineForPatient: VaccineForPatient[] = [
    new VaccineForPatient(0, 0, 0, new Date(),new Vaccine(0,""),new Patient(0, "", "", "", "", "", "", "", 0, new Date(), new Date(), new Date(),"")),
    new VaccineForPatient(0, 0, 0, new Date(),new Vaccine(0,""),new Patient(0, "", "", "", "", "", "", "", 0, new Date(), new Date(), new Date(),"")),
    new VaccineForPatient(0, 0, 0, new Date(),new Vaccine(0,""),new Patient(0, "", "", "", "", "", "", "", 0, new Date(), new Date(), new Date(),"")),
    new VaccineForPatient(0, 0, 0, new Date(),new Vaccine(0,""),new Patient(0, "", "", "", "", "", "", "", 0, new Date(), new Date(), new Date(),""))
  ];
  formData:FormData=new FormData()
  formdataimg:FormData=new FormData()
  constructor(private db: SharedServiceService) { }
  ngOnInit(): void {
    this.RefreshVaccinesLst();

  }

  RefreshVaccinesLst() {
    this.db.getAllvaccinations().subscribe(x => {
      this.arrV = <Vaccine[]>x;
      console.log(this.arrV)
    });
  }
  continue() {
    this.firstHalf = false
    this.secondHalf = true
  }
  back() {
    this.firstHalf = true
    this.secondHalf = false
  }
  addUser() {
    console.log(this.p);
      this.db.addUser(this.p).subscribe(x => {
        this.x = <number>x;
        console.log(x);
        this.RefreshPatientsLst()
        this.arrVaccineForPatient.forEach(v => {
          console.log(v);
          v.patient=this.arrp.find(element => element.id===this.x)|| new Patient(0, '', '', '', '', '', '', '', 0, new Date(), new Date(), new Date(),"");
          v.vaccine=this.arrV.find(element => element.id===this.x)|| new Vaccine(0,"");
          v.patientID = this.x;
          if (v.vaccineID !== 0) {
            this.db.addVaccinesForPatient(v).subscribe(y => {
              console.log(y);
            });
          }
        });
      })
  }
  RefreshPatientsLst(){
    this.db.GetAllUsers() .subscribe(x=>{     
      this.arrp=<Patient[]>x;
      console.log(this.arrp)
      this.arrp.map(x=>x.dateOfBirth)
    });
  }
  uploadPhoto(event: any) {
    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('file', file);
    this.formdataimg=formData
    console.log(this.formdataimg);
    var reader=new FileReader()
    reader.readAsDataURL(event.target.files[0])
    reader.onload=(e:any)=>{
      this.url=e.target.result
      console.log(this.url);
      
    }
    this.db.UploadImage(formData).subscribe(x => {
      this.PhotoFilePath = <any>x;
      console.log(this.PhotoFilePath);
    }
    )
  }
}
