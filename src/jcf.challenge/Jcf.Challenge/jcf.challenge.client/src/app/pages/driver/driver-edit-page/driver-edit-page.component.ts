import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-driver-edit-page',
  templateUrl: './driver-edit-page.component.html'
})
export class DriverEditPageComponent implements OnInit {
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
    private activatedRouter: ActivatedRoute,
    private dataService: DataService,
    private fb: FormBuilder
  ) {
    this.form = this.fb.group({});
  }

  ngOnInit(): void {
    var id = this.activatedRouter.snapshot.paramMap.get("id");

    this
      .dataService
      .driverGet(id)
      .subscribe({
        next: (data: any) => {

          this.form = this.fb.group({

            name: [data.name, Validators.compose([
              Validators.minLength(5),
              Validators.maxLength(200),
              Validators.required
            ])],

            documentNumber: [data.documentNumber, Validators.compose([
              Validators.minLength(14),
              Validators.maxLength(14),
              Validators.required
            ])],

            licenseNumber: [data.licenseNumber, Validators.compose([
              Validators.minLength(14),
              Validators.maxLength(14),
              Validators.required
            ])],

            licenseCategories: [data.licenseCategories, Validators.compose([
              Validators.required
            ])],

            dataOfBirth: [data.dataOfBirth, Validators.compose([
              Validators.required
            ])],

            status: [data.status, Validators.compose([
              Validators.required
            ])],

            id: [data.id]
          });
        },
        error: (err) => {

        }
      });
  }

  edit(): void {
    this
      .dataService
      .driverUpdate(this.form.value)
      .subscribe({
        next: (data: any) => {
          this.router.navigate(['/app/motoristas']);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
