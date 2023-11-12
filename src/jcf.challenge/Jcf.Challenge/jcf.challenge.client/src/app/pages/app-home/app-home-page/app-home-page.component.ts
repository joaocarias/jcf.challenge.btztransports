import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../../services/data/data.service";

@Component({
  selector: 'app-app-home-page',
  templateUrl: './app-home-page.component.html'
})
export class AppHomePageComponent implements OnInit {
  

  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    
  }
}
