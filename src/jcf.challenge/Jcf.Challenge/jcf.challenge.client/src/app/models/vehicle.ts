export class Vehiche {
  constructor(
    public id: string | null,
    public name: string,
    public plate: number,
    public fuelType: number,
    public manufacturer: string,
    public yearManufacture: number,
    public maxCapacityFuel: Number,
    public observation: string,
  ) {
    
  }

  public fuelTypeDescriptin(): string {
    var listFuelType =
      [
        { id: 1, name: 'Gasolina' },
        { id: 2, name: 'Etanol' },
        { id: 3, name: 'Deesel' }
      ];

    return listFuelType[this.fuelType].name;
  }
}
