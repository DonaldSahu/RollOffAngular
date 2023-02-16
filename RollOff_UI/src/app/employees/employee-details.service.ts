import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import{GetAllEmployeeResponse} from '../Models/api-models/getallstudentresponse.models'
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private httpClient:HttpClient) { }

  getEmployee():Observable<any[]>{
    return this.httpClient.get<any[]>(this.baseApiUrl+'Api/RollOff');
  }

  getEmployeebyid(employeeid:string):Observable<any>{
    return this.httpClient.get<any>(this.baseApiUrl+'Api/RollOff/'+employeeid);
  }

  saveFormData(data:any){
     console.log(data);
     return this.httpClient.post(this.baseApiUrl+'Api/Form',data);
  }
}
