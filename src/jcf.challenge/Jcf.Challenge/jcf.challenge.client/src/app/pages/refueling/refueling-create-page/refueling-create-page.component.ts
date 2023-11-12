import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Vehiche } from "../../../models/vehicle";
import { Driver } from "../../../models/driver";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-refueling-create-page',
  templateUrl: './refueling-create-page.component.html'
})
export class RefuelingCreatePageComponent implements OnInit {
  
  public vehicles?: Array<Vehiche> | null;
  public drivers?: Array<Driver> | null;
  public form: FormGroup;
  public messageError: string;

  constructor(
    private router: Router,
    private dataService: DataService,
    private fb: FormBuilder
  ) {

    this.form = this.fb.group({

      vehicleId: ['', Validators.compose([        
        Validators.required
      ])],

      driverId: ['', Validators.compose([       
        Validators.required
      ])],

      dateRefueling: ['', Validators.compose([
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.required
      ])],

      fuelType: ['', Validators.compose([
        Validators.required
      ])],

      quantity: ['', Validators.compose([
        Validators.min(0),
        Validators.required
      ])],

    });

    this.messageError = "";
  }

  ngOnInit(): void {
    this.getVehicles();
    this.getDrivers();
  }

  getVehicles(): void {
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

  getDrivers(): void  {
    this
      .dataService
      .driverGetAll()
      .subscribe({
        next: (data: any) => {
          this.drivers = data;
        },
        error: (err) => {
          console.log(err);
        }
      });
  }

  submit(): void {
    this
      .dataService
      .refuelingCreate(this.form.value)
      .subscribe({
        next: (data: any) => {
          console.log(data);
          this.router.navigate(['/app/abastecimentos']);
        },
        error: (err) => {
          console.log(err);
          this.messageError = err.error.message;
        }
      });
  }
}
