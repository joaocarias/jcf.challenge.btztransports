import { Driver } from "./driver";
import { Vehiche } from "./vehicle";

export class Refueling {
  
  constructor(
    public id: string | null,
    public vehicleId: string,
    public vehicle: Vehiche | null,
    public driverId: string,
    public driver: Driver | null,
    public dateRefueling: Date,
    public fuelType: number,
    public quantity: number,
    public paidAmount: number
  ) {

  }

  public fuelTypeDescription(): string {
    var listFuelType =
      [
          { id: 1, name: 'Gasolina' },
          { id: 2, name: 'Etanol' },
          { id: 3, name: 'Deesel' }
      ];

    return listFuelType[this.fuelType].name;
  }
}
