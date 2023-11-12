import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { Security } from "../../../utils/security";
import { User } from "../../../models/user.model";
import { DataService } from "../../../services/data/data.service";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'
})
export class LoginPageComponent implements OnInit {
  public form: FormGroup;

  constructor(
    private router: Router,
    private dataService: DataService,
    private fb: FormBuilder
  ) {
    this.form = this.fb.group({
      username: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(200),
        Validators.email,
        Validators.required
      ])],
      password: ['', Validators.compose([
        Validators.minLength(6),
        Validators.maxLength(16),
        Validators.required
      ])]
    });
  }

    ngOnInit(): void {
    
    }

  setUser(user: User, token: string) {
    Security.set(user, token);
    this.router.navigate(['/manager']);
  }
}
