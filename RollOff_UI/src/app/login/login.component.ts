import { Component, OnInit, } from '@angular/core';
import { FormControl, FormGroup,Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { EmployeeDetailsService } from 'app/services/employee-details.service';
import { TopNavComponent } from 'app/top-nav/top-nav.component';

@Component({ 
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']})
  
export class LoginComponent implements OnInit 
{ 
  model:any = {};
  responsedata:any;
  role : any = ["Admin","Accounts","PSP"]
  //isUserValid: boolean | undefined;  
  hide = true;
  floatLabelControl = new FormControl('auto' as FloatLabelType);

  constructor(private loginAuth: EmployeeDetailsService, private _router: Router) {}
  
  Userlogin(){
    console.log(this.loginForm.value);
    this.loginAuth.login(this.loginForm.value).subscribe({
      next: response=>{
        if(response!=null){
          this.responsedata = response;
          localStorage.setItem('token',this.responsedata.result);
          localStorage.setItem('role',JSON.stringify(this.loginForm.value.department));
          if(this.loginForm.value.department== 'Admin'){
            this._router.navigate(["app-employees"])
          }
        }
      },
      error: error=>{
        if(error.status == 400){
       console.log("Invalid details");
        }
      }
    });
  }


ngOnInit(): void {}

loginForm = new FormGroup({
  email :new FormControl("",[Validators.required,Validators.email]),
  password: new FormControl("",[Validators.required,Validators.minLength(6),
  Validators.maxLength(15),
]),
department: new FormControl(''),
});


// isUserValid :boolean =false;
// loginSubmited(){
//   //console.log(this.loginForm);      
//   this.loginAuth. login([
//   this.loginForm.value.email,
//   this.loginForm.value.password]
//   ).subscribe(res=>{
//     console.log(res);
//   });

//     }
    
    get Email() :FormControl{
      return this.loginForm.get('email') as FormControl;
    }
    get Password():FormControl{
      return this.loginForm.get('password') as FormControl;
    }
    get Department():FormControl{
      return this.loginForm.get('department') as FormControl;
    }

    changeRole(e:any){
      console.log(e.target.value);
    }
  }