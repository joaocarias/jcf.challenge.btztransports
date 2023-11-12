import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";
import { Driver } from "../../../models/driver";

@Component({
  selector: 'app-driver-create-page',
  templateUrl: './driver-create-page.component.html'
})
export class DriverCreatePageComponent implements OnInit {
  
  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
  
  }
}
