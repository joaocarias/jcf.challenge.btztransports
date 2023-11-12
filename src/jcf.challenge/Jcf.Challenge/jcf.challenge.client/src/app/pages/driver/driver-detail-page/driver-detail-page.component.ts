import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Driver } from "../../../models/driver";

@Component({
  selector: 'app-driver-detail-page',
  templateUrl: './driver-detail-page.component.html'
})
export class DriverDetailPageComponent implements OnInit {
  public driver?: Driver | null;

  constructor(
    private activeRoute: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) {

  }

  ngOnInit(): void {

    var id = this.activeRoute.snapshot.paramMap.get("id");
    this
      .dataService
      .driverGet(id)
      .subscribe({
        next: (data: any) => {
          this.driver = data;
        },
        error: (err) => {

        }
      });
  }

  delete(id: any): void {
    var _id = this.activeRoute.snapshot.paramMap.get("id");
    this
      .dataService
      .driverDelete(_id)
      .subscribe({
        next: (data: any) => {
          this.router.navigate(['/app/drivers']);
        },
        error: (err) => {

        }
      });
  }
}
