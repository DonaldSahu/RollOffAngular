import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { FeedbackFormComponent } from './feedback-form/feedback-form.component';
import { LoginComponent } from './login/login.component';
import { AuthGuardService } from './services/auth-guard.service';
import { TempComponent } from './temp/temp.component';

const routes: Routes = [
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'app-employees',
    component:EmployeesComponent,
    canActivate:[AuthGuardService]
  },
  {
    path:'app-temp',
    component:TempComponent
  },
  {
    path:'app-employees/:id',
    component:ViewEmployeeComponent
  },
  {
    path:'feedback-form/:id',
    component:FeedbackFormComponent
  },
  {
    path:'app-login',
    component:LoginComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
