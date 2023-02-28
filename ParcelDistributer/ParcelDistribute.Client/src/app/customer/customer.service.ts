import { Injectable } from '@angular/core';
import { Customer } from './customer.model';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  formData: Customer = new Customer();
  readonly baseURL = 'http://localhost:5114/api/Customer';
  list: Customer[];

  constructor(private http: HttpClient) { }

  PostCustomerDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  PutCustomertDetail() {
    return this.http.put(this.baseURL, this.formData);
  }

  DeleteCustomer(id: number) {
    return this.http.delete(`${this.baseURL}/?numCustomerID=${id}`);
  }

  GetCustomerDetails(): Observable<any> {
    return this.http.get<any>(this.baseURL).pipe();
  }
}
