import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Driver } from "../../../models/driver";

@Component({
  selector: 'app-driver-page',
  templateUrl: './driver-page.component.html'
})
export class DriverPageComponent implements OnInit {
  public drivers?: Array<Driver> | null;

  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
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
}
