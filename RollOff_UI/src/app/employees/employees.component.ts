import { Component,OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';

import { MatTableDataSource } from '@angular/material/table';
import{ EmployeeDetailsService} from '../services/employee-details.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees:any[]=[];
  displayedColumns: string[] = ['globalGroupID','employeeNo','name','localGrade','email','edit'];
  dataSource:MatTableDataSource<any>=new MatTableDataSource<any>();

  @ViewChild(MatPaginator) matPaginator!:MatPaginator;
  filterString='';

  constructor(private employeeDetailsService: EmployeeDetailsService){}

  ngOnInit(): void {
    //fetch employees
    this.employeeDetailsService.getEmployee().subscribe((successResponse)=>{
      this.employees=successResponse;
      this.dataSource=new MatTableDataSource<any>(this.employees);

      if(this.matPaginator){
        this.dataSource.paginator=this.matPaginator;
      }
    },
    (errorResponse)=>{
      console.log(errorResponse);
      
    }
    );
  }

  filterEmployees(){
    this.dataSource.filter=this.filterString.trim().toLowerCase();
  }
}


