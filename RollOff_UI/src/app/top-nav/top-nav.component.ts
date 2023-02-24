import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from 'app/services/employee-details.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit{
  user:any;
  Isloggedin:boolean = false;

  constructor(private empservice:EmployeeDetailsService){}

  ngOnInit(): void {
    this.checkstorage();
  }

  checkstorage()
  {
    this.user =localStorage.getItem('token');
    if(this.user!=null){
      this.Isloggedin =true;
    }
    // this.Isloggedin = this.empservice.navLogin();
    // console.log(this.Isloggedin);
    
  }

  logout()
  {
    localStorage.clear();
    this.Isloggedin=false;
  }


}
