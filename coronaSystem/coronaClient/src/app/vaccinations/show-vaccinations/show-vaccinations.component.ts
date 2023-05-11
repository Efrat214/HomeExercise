import { Component } from '@angular/core';
import { SharedServiceService } from 'src/app/shared-service.service';
import { Vaccine } from 'src/app/Vaccine';

@Component({
  selector: 'app-show-vaccinations',
  templateUrl: './show-vaccinations.component.html',
  styleUrls: ['./show-vaccinations.component.css']
})
export class ShowVaccinationsComponent {
arrv:Vaccine[]=[]
v:Vaccine=new Vaccine(0,"")
constructor(private db:SharedServiceService){}
ngOnInit(): void {
  this.RefreshvaccinationsLst();  
}
RefreshvaccinationsLst(){
  this.db.getAllvaccinations() .subscribe(x=>{     
    this.arrv=<Vaccine[]>x;
    console.log(this.arrv)
  });
}
}
