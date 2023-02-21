import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from 'environments/environment.development';
import { User } from 'app/models/user';
//import{GetAllEmployeeResponse} from '../Models/api-models/getallstudentresponse.models'

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  baseApiUrl:string=environment.baseApiUrl;

  constructor(private httpClient:HttpClient) { }

  getEmployee():Observable<any[]>{
    return this.httpClient.get<any[]>(this.baseApiUrl+'RollOff');
  }

  getEmployeebyid(employeeid:string):Observable<any>{
    return this.httpClient.get<any>(this.baseApiUrl+'RollOff/'+employeeid);
  }

  saveFormData(data:any){
     console.log(data);
     return this.httpClient.post(this.baseApiUrl+'Api/Form',data);
  }
  
  login(model: any){
  return this.httpClient.post(
    this.baseApiUrl + "api/Auth/Login",model);
  }

  loggedIn(){
     return !! localStorage.getItem('token')
  }
}