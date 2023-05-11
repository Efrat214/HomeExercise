import { Patient } from "./patients/Patient";
import { Vaccine } from "./Vaccine";

export class VaccineForPatient{
    constructor
    (
        public id: number,
        public patientID: number,
        public vaccineID:number,
        public date:Date,
        public vaccine:Vaccine,
        public patient:Patient
    ){}  
}