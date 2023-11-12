import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Driver } from "../../../models/driver";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-driver-create-page',
  templateUrl: './driver-create-page.component.html'
})
export class DriverCreatePageComponent implements OnInit {
  public form: FormGroup;
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

      licenseCategories: ['', Validators.compose([        
        Validators.required
      ])],

      dataOfBirth: ['', Validators.compose([        
        Validators.required
      ])],

      status: ['', Validators.compose([
        Validators.required
      ])],

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
}
