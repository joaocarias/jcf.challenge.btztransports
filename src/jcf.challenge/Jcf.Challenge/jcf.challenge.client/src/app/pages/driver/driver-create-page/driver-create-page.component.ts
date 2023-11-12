import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-driver-create-page',
  templateUrl: './driver-create-page.component.html'
})
export class DriverCreatePageComponent implements OnInit {
  public form: FormGroup;

  public dataLincenses = [
    { id: 1, name: 'ACC' },
    { id: 2, name: 'A' },
    { id: 3, name: 'B' },
    { id: 4, name: 'C' },
    { id: 5, name: 'D' },
    { id: 6, name: 'E' },
  ];

  constructor(
    private router: Router,
    private dataService: DataService,
    private fb: FormBuilder
  ) {

    this.form = this.fb.group({

      name: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(200),        
        Validators.required
      ])],

      documentNumber: ['', Validators.compose([
        Validators.minLength(14),
        Validators.maxLength(14),
        Validators.required
      ])],

      licenseNumber: ['', Validators.compose([
        Validators.minLength(14),
        Validators.maxLength(14),
        Validators.required
      ])],

      licenseCategories: [[2], Validators.compose([        
        Validators.required
      ])],

      dataOfBirth: ['', Validators.compose([        
        Validators.required
      ])],

      status: ['', Validators.compose([
        Validators.required
      ])],

      orders: new FormArray([])

    });

  }

  ngOnInit(): void {
    
  }

  submit(): void {
      this
        .dataService
        .driverCreate(this.form.value)
          .subscribe({
            next: (data: any) => {
              console.log(data);
              this.router.navigate(['/app/motoristas']);
            },
            error: (err) => {
              console.log(err);
            }
          });
  }

  get ordersFormArray() {
    return this.form.controls.orders as FormArray;
  }

  private addCheckboxes() {
    this.dataLincenses.forEach(() => this.ordersFormArray.push(new FormControl(false)));
  }
}
