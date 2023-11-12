export class Driver {
  constructor(
    public id: string | null,
    public name: string,
    public documentNumber: string,
    public licenseNumber: string,
    public licenseCategory: number,
    public dateOfBirth: Date,
    public status: boolean | true   
  ) {    
   
  }

  
  
}
