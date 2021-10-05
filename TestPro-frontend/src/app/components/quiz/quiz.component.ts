import { Test } from './../../models/Test';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {
  test?: Test;

  answers: string[] = []

  cur_title?: string
  cur_a?: string
  cur_b?: string
  cur_c?: string
  cur_d?: string

  check_a:boolean = false;
  check_b:boolean = false;
  check_c:boolean = false;
  check_d:boolean = false;

  i: number = 0

  constructor( private router: Router) { }

  ngOnInit(): void {
    this.test = new BehaviorSubject<Test>(JSON.parse(localStorage.getItem('test') || '{}')).value;
    console.log(this.test)

    this.cur_title = this.test.questions[this.i].title
    this.cur_a = this.test.questions[this.i].answers[0]
    this.cur_b = this.test.questions[this.i].answers[1]
    this.cur_c = this.test.questions[this.i].answers[2]
    this.cur_d = this.test.questions[this.i].answers[3]
  }

  onClick(): void {
    if(this.check_a){
      this.answers.push(this.cur_a || '')
    } else if (this.check_b) {
      this.answers.push(this.cur_b || '')
    } else if (this.check_c) {
      this.answers.push(this.cur_c || '')
    } else {
      this.answers.push(this.cur_d || '')
    }
    this.i += 1
    if(this.i > 4){
      localStorage.setItem('answers', JSON.stringify(this.answers))
      console.log(this.answers)
      this.router.navigate(['/result']);

    } else {
      this.cur_title = this.test?.questions[this.i].title
      this.cur_a = this.test?.questions[this.i].answers[0]
      this.cur_b = this.test?.questions[this.i].answers[1]
      this.cur_c = this.test?.questions[this.i].answers[2]
      this.cur_d = this.test?.questions[this.i].answers[3]
    }

  }

}
