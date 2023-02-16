import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { ViewEmployeeComponent } from './employees/view-employee/view-employee.component';
import { FeedbackFormComponent } from './feedback-form/feedback-form.component';
import { TempComponent } from './temp/temp.component';

const routes: Routes = [
  {
    path:'',
    component:EmployeesComponent
  },
  {
    path:'app-employees',
    component:EmployeesComponent
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
