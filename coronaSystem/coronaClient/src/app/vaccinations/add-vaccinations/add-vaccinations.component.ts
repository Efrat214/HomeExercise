import { Component } from '@angular/core';
import { SharedServiceService } from 'src/app/shared-service.service';
import { Vaccine } from 'src/app/Vaccine';

@Component({
  selector: 'app-add-vaccinations',
  templateUrl: './add-vaccinations.component.html',
  styleUrls: ['./add-vaccinations.component.css']
})
export class AddVaccinationsComponent {
  v: Vaccine = new Vaccine(0, "")
  x:number=0
  constructor(private db: SharedServiceService) { }
  addvaccine() {
    console.log(this.v);

    this.db.addVaccine(this.v).subscribe(x => {
      this.x = <number>x;
      console.log(x);

    })
  }
}
