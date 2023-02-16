import { Component } from '@angular/core';
import { FormGroup, FormControl,} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.development';
import { EmployeeDetailsService } from '../employees/employee-details.service';


@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})
export class FeedbackFormComponent {

  constructor(private employeeService:EmployeeDetailsService, 
    private readonly route:ActivatedRoute){}

  employeeId:string|null|undefined;
  employee:any={
     globalGroupId:0,
     name: '',
     localGrade: '',
     mainClient: '', 
     email: '',
     joiningDate:new Date, 
      projectCode:0 ,
      projectName: '',
      projectStartDate:new Date,
      projectEndDate: new Date,
      peopleManager: '',
      practice: '',
      pspName: '',
      newGlobalPractice: '',
      officeCity: '',
      country: ''
      }

   
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params)=>{
        this.employeeId=params.get('id');
        if(this.employeeId){
          this.employeeService.getEmployeebyid(this.employeeId)
          .subscribe(
            (successResponse)=>{
              this.employee=successResponse;
              console.log(this.employee)
            }
          );
        }
      }
    ); 
  }

  addForms = new FormGroup({
    globalGroupId : new FormControl(0),
    name : new FormControl(''),
    practice : new FormControl(''),
    performanceIssue : new FormControl(''),
    technicalSkills : new FormControl(''),
    localGrade : new FormControl(''),
    rollOffEndDate : new FormControl(''),
    resigned : new FormControl(''),
    communication : new FormControl(''),
    primarySkills : new FormControl(''),
    reasonForRollOff : new FormControl(''),
    underProbation : new FormControl(''),
    roleCompetencies : new FormControl(''),
    projectCode : new FormControl(0),
    longLeave : new FormControl(''),
    remarks : new FormControl(''),
    projectName : new FormControl(''),
    thisReleaseNeedsBackfilled : new FormControl(''),
    relevantExperienceInYears : new FormControl(0),
    leaveType : new FormControl(''),
    //otherReasons : new FormControl('')
  }
 );

  get GGID(){
    return this.addForms.get('globalGroupId') as FormControl;
  }

  SaveData(){
    
    console.log(this.addForms.value);
    this.employeeService.saveFormData(this.addForms.value).subscribe((result)=>{
      console.log(result);
    });
  }
}


