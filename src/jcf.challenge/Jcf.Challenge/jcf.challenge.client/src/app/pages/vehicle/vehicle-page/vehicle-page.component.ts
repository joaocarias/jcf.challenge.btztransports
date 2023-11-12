import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Vehiche } from "../../../models/vehicle";

@Component({
  selector: 'app-vehicle-page',
  templateUrl: './vehicle-page.component.html'
})
export class VehiclePageComponent implements OnInit {
  public vehicles?: Array<Vehiche> | null;

  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

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
