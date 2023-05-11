export class Patient{
    constructor
    (
        public id: number,
        public firstName: string,  
        public lastName: string,  
        public patientId: string,  
        public telephone:string,
        public mobilePhone:string,
        public city: string,  
        public street: string,  
        public numHouse: number,
        public dateOfBirth:Date,
        public positiveResultDate:Date,
        public recoveryDate:Date,
        public imagePath:string
        ){}  
}