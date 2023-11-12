import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-vehicle-create-page',
  templateUrl: './vehicle-create-page.component.html'
})
export class VehicleCreatePageComponent implements OnInit {
  public form: FormGroup;
  public fuelTypes: Array<string>;

  constructor(
    private router: Router,
    private dataService: DataService,
    private fb: FormBuilder
  ) {

    this.fuelTypes = ["Gasolina", "Etanol", "Diesel"];

    this.form = this.fb.group({

      name: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(200),
        Validators.required
      ])],

      plate: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(14),
        Validators.required
      ])],

      fuelType: ['', Validators.compose([        
        Validators.required
      ])],

      manufacturer: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(200),
        Validators.required
      ])],

      yearManufacture: ['', Validators.compose([
        Validators.minLength(4),
        Validators.maxLength(4),
        Validators.required
      ])],

      maxCapacityFuel: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(4),
        Validators.required
      ])],

      observation: ['']
    });
  }

  ngOnInit(): void {

  }

  submit(): void {
    this
      .dataService
      .vehicleCreate(this.form.value)
      .subscribe({
        next: (data: any) => {
          console.log(data);
          this.router.navigate(['/app/veiculos']);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
