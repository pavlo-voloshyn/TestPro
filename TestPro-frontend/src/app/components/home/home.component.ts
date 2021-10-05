import { Test } from './../../models/Test';
import { AuthService } from './../../services/auth.service';
import { TestService } from './../../services/test.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  tests: Test[] = [];
  selectedTest?: Test;
  constructor(private testService: TestService, private authService: AuthService, private router: Router) {
  }

  ngOnInit(): void {
    const currentUser = this.authService.currentUserValue;

    this.testService.getTests(currentUser.id).subscribe(
      data => {

        this.tests = data;
        console.log('Current Tests: ', this.tests);
      },
      error  => {
        console.log('Error Getting Tests: ', error);
      });
  }


  onSelect(test: Test): void {
    console.log(test.desсription)
    this.selectedTest = test;

    localStorage.setItem("test", JSON.stringify(test))

    this.router.navigate(['/test-desc'], { queryParams: { id: test.id, desc: test.desсription} });
  }

}
