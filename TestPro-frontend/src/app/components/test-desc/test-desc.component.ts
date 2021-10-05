import { Test } from './../../models/Test';
import { AuthService } from './../../services/auth.service';
import { TestService } from './../../services/test.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-test-desc',
  templateUrl: './test-desc.component.html',
  styleUrls: ['./test-desc.component.css']
})
export class TestDescComponent implements OnInit {
  desc: string = '';
  test_id: string = '';
  check = false;

  constructor(private route: ActivatedRoute,  private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.test_id = params['testId'];
      this.desc = params['desc'];
    })
  }

  onClick(): void {
    this.router.navigate(['/quiz']);
  }

}
