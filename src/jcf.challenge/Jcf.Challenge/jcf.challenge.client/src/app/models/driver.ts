export class Driver {
  constructor(
    public _id: string | null,
    public name: string,
    public documentNumber: string,
    public licenseNumber: string,
    public licenseCategories: Array<string>,
    public dataOfBirth: Date,
    public status: boolean,
    public createdAt: Date     
  ) {    

  }
}
