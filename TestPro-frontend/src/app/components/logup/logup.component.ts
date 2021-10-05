import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-logup',
  templateUrl: './logup.component.html',
  styleUrls: ['./logup.component.css']
})
export class LogupComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthService
  ) {
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required]});
      // if (this.authenticationService.currentUserValue) {
      //   this.router.navigate(['/']);
      // }
  }

  ngOnInit() {
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
      this.submitted = true;

      if (this.loginForm.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.logup(this.f.name.value, this.f.username.value, this.f.password.value).pipe(first())
      .subscribe({
          next: () => {
              this.router.navigate(['login']);
          },
          error: error => {
              this.error = error;
              this.loading = false;
          }
      });


  }
}
