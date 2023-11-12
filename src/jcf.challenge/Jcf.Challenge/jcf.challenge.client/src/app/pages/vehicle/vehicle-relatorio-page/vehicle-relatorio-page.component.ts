import { Component, OnInit } from "@angular/core";
import { Vehiche } from "../../../models/vehicle";
import { DataService } from "../../../services/data/data.service";

@Component({
  selector: 'app-vehicle-relatorio-page',
  templateUrl: './vehicle-relatorio-page.component.html'
})
export class VehicleRelatorioPageComponent implements OnInit {
  public vehicles?: Array<Vehiche> | null;

  constructor(   
    private dataService: DataService
  ) {

  }

  ngOnInit(): void {
    this
      .dataService
      .vehicleGetAll()
      .subscribe({
        next: (data: any) => {
          this.vehicles = data;
        },
        error: (err) => {

        }
      });
  }
}
