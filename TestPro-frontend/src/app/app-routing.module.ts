import { LogupComponent } from './components/logup/logup.component';
import { ResultComponent } from './components/result/result.component';
import { QuizComponent } from './components/quiz/quiz.component';
import { TestDescComponent } from './components/test-desc/test-desc.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'test-desc', component: TestDescComponent, canActivate: [AuthGuard] },
  { path: 'quiz',  component: QuizComponent, canActivate: [AuthGuard]},
  { path: 'result',  component: ResultComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'logup', component: LogupComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
