import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Vehiche } from "../../../models/vehicle";

@Component({
  selector: 'app-vehicle-detail-page',
  templateUrl: './vehicle-detail-page.component.html'
})
export class VehicleDetailPageComponent implements OnInit {  
  public fuelTypes: Array<string>;
  public vehiche?: Vehiche | null;

  constructor(
    private activeRoute: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) {

    this.fuelTypes = ["Gasolina", "Etanol", "Diesel"];

  }

  ngOnInit(): void {

    var id = this.activeRoute.snapshot.paramMap.get("id");    
    this
      .dataService
      .vehicheGet(id)
      .subscribe({
        next: (data: any) => {
          this.vehiche = data;
        },
        error: (err) => {

        }
      });
  }

  delete(id: any) : void{
    var _id = this.activeRoute.snapshot.paramMap.get("id");
    this
      .dataService
      .vehicleDelete(_id)
      .subscribe({
        next: (data: any) => {
          this.router.navigate(['/app/veiculos']);
        },
        error: (err) => {

        }
      });
  }
}
