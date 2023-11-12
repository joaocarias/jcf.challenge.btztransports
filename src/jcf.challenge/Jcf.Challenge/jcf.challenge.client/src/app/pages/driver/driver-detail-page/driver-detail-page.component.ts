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
  public licenses = [
    'ACC',
    'A',
    'B',
    'C',
    'D',
    'E',
  ];
  public myLicense: string | null;

  constructor(
    private activeRoute: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) {
    this.myLicense = "";
  }

  getLicenseCategoryDescription(_licenseCategory: any): string {
    switch (_licenseCategory) {
      case 1:
        return 'ACC';
      case 2:
        return 'A';
      case 3:
        return 'B';
      case 4:
        return 'C';
      case 5:
        return 'D';
      case 6:
        return 'E';

      default:
        return 'Categoria Desconhecida';
    }
  }

  ngOnInit(): void {

    var id = this.activeRoute.snapshot.paramMap.get("id");
    this
      .dataService
      .driverGet(id)
      .subscribe({
        next: (data: any) => {
          this.driver = data;
          this.myLicense = this.getLicenseCategoryDescription(this.driver?.licenseCategory);
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
          this.router.navigate(['/app/motoristas']);
        },
        error: (err) => {

        }
      });
  }

 }
