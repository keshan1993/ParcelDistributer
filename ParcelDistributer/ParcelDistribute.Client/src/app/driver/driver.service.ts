import { Injectable } from '@angular/core';
import { Driver } from './driver.model';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  formData: Driver = new Driver();
  readonly baseURL = 'http://localhost:5114/api/Driver';
  list: Driver[];

  constructor(private http: HttpClient) { }

  PostDriverDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  PutDrivertDetail() {
    return this.http.put(this.baseURL, this.formData);
  }

  DeleteDriver(id: number) {
    return this.http.delete(`${this.baseURL}/?numDriverID=${id}`);
  }

  GetDriverDetails(): Observable<any> {
    return this.http.get<any>(this.baseURL).pipe();
  }

  GetAvailableDrivers(dtDeliveryDate: string): Observable<any> {
    return this.http.get<any>(`${this.baseURL}/GetAvailableDrivers/?dtDeliveryDate=${dtDeliveryDate}`).pipe();
  }

}
