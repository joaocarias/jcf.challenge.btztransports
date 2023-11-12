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
  public messageError: string;

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

    this.messageError = "";
  }

  ngOnInit(): void {
    
  }

  submit(): void {
    this
      .dataService
      .authenticate(this.form.value)
      .subscribe({
        next: (data: any) => {
          console.log(data);
          this.setUser(new User(data.user.Id, data.user.name, data.user.email, null, data.user.firstName), data.token);
        },
        error: (err) => {
          console.log(err);
          this.messageError = err.error.message;
          Security.clear();
        }
      });      
  }

  setUser(user: User, token: string) {
    Security.set(user, token);
    this.messageError = "";
    this.router.navigate(['/app']);
  }
}
