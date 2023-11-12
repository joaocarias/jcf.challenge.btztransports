export class Vehiche {
  constructor(
    public id: string | null,
    public name: string,
    public plate: Number,
    public fuelType: Number,
    public manufacturer: string,
    public yearManufacture: number,
    public maxCapacityFuel: Number,
    public observation: string,
  ) {
    
  }
}
