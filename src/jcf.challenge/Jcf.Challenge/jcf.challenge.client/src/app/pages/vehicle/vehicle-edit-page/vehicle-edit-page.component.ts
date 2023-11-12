import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Vehiche } from "../../../models/vehicle";

@Component({
  selector: 'app-vehicle-edit-page',
  templateUrl: './vehicle-edit-page.component.html'
})
export class VehicleEditPageComponent implements OnInit {
  public form: FormGroup;
  public fuelTypes: Array<string>;
  public vehiche?: Vehiche | null;

  constructor(
    private activatedRouter: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private fb: FormBuilder
  ) {

    this.fuelTypes = ["Gasolina", "Etanol", "Diesel"];
    this.form = this.fb.group({});
  }

  ngOnInit(): void {

    var id = this.activatedRouter.snapshot.paramMap.get("id");
    this
      .dataService
      .vehicheGet(id)
      .subscribe({
        next: (data: any) => {

          this.form = this.fb.group({

            name: [data.name, Validators.compose([
              Validators.minLength(1),
              Validators.maxLength(200),
              Validators.required
            ])],

            plate: [data.plate, Validators.compose([
              Validators.minLength(1),
              Validators.maxLength(14),
              Validators.required
            ])],

            fuelType: [data.fuelType, Validators.compose([
              Validators.required
            ])],

            manufacturer: [data.manufacturer, Validators.compose([
              Validators.minLength(1),
              Validators.maxLength(200),
              Validators.required
            ])],

            yearManufacture: [data.yearManufacture, Validators.compose([
              Validators.minLength(4),
              Validators.maxLength(4),
              Validators.required
            ])],

            maxCapacityFuel: [data.maxCapacityFuel, Validators.compose([
              Validators.minLength(1),
              Validators.maxLength(4),
              Validators.required
            ])],

            observation: [data.observation],

            id: [data.id]
          });
        },
        error: (err) => {

        }
      });

  }

  Edit(): void {
    this
      .dataService
      .vehicleUpdate(this.form.value)
      .subscribe({
        next: (data: any) => {       
          this.router.navigate(['/app/veiculos']);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
