import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Refueling } from "../../../models/refueling";


@Component({
  selector: 'app-refueling-relatorio-page',
  templateUrl: './refueling-relatorio-page.component.html'
})
export class RefuelingRelatorioPageComponent implements OnInit {
  public refuelings?: Array<Refueling> | null;

  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this
      .dataService
      .refuelingGetAll()
      .subscribe({
        next: (data: any) => {
          this.refuelings = data;
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
