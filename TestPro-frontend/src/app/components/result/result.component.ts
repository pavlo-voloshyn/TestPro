import { TestService } from './../../services/test.service';
import { Test } from './../../models/Test';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  test_id?:string
  answers:string[] = []

  res:number = 0

  constructor(private router: Router, private testService: TestService) { }

  ngOnInit(): void {
    this.test_id = new BehaviorSubject<Test>(JSON.parse(localStorage.getItem('test') || '{}')).value.id;
    this.answers = new BehaviorSubject<Array<string>>(JSON.parse(localStorage.getItem('answers') || '{}')).value;


    this.testService.getResult(this.test_id, this.answers).subscribe(
      data =>{
        for(let i = 0; i < 5; i++) {
          if(data[i] == true) {
            this.res += 1;
          }
        }
      },
      error  => {
        console.log('Error Getting Tests: ', error);
      });
    console.log(this.res)
  }

  onClick():void {
    this.router.navigate(['/']);
  }

}
