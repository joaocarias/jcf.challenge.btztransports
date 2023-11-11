import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasicInformations } from '../../../models/basic-informations.model';
import { DataService } from '../../../services/data/data.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html'
})
export class HomePageComponent implements OnInit {
  public basicInformations?: BasicInformations | null;

  constructor(
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this
      .dataService
      .getInformations()
      .subscribe({
        next: (data: BasicInformations) => {
          this.basicInformations = new BasicInformations(data.address, data.fones, data.email, data.horarioAtendimento);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
