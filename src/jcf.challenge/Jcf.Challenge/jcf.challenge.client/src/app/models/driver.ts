export class Driver {
  constructor(
    public id: string | null,
    public name: string,
    public documentNumber: string,
    public licenseNumber: string,
    public licenseCategories: Array<number> | [2],
    public dataOfBirth: Date,
    public status: boolean | true   
  ) {    
   
  }
}
