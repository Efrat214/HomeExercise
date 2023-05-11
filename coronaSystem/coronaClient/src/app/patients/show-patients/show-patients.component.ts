import { Component } from '@angular/core';
import { SharedServiceService } from 'src/app/shared-service.service';
import { Vaccine } from 'src/app/Vaccine';
import { Patient } from '../Patient';
import { NgOptimizedImage } from '@angular/common'

@Component({
  selector: 'app-show-patients',
  templateUrl: './show-patients.component.html',
  styleUrls: ['./show-patients.component.css']
})
export class ShowPatientsComponent {
  arrp:Patient[]=[];
   arrV:any[]=[]
  ActivateComp:boolean=false;
  constructor(private db:SharedServiceService){}
  ngOnInit(): void {
    this.RefreshPatientsLst();
    console.log(this.ActivateComp);
    
  }
  RefreshPatientsLst(){
    this.db.GetAllUsers() .subscribe(x=>{     
      this.arrp=<Patient[]>x;
      console.log(this.arrp)
      this.arrp.map(x=>x.dateOfBirth)
    });
  }
  addClick(){
    this.ActivateComp=true;
  }
  closeClick(){
    this.ActivateComp=false;
    this.RefreshPatientsLst();
  }
  show(item:Patient)
  {
    console.log(item.id);
    this.db.getVaccinesForPatient(item.id).subscribe(x=>{
      this.arrV=<any>x;
      console.log(this.arrV);
    })
  }
}
