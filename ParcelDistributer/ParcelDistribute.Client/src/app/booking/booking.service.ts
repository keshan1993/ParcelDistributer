import { Injectable } from '@angular/core';
import { Booking } from './booking.model';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  formData: Booking = new Booking();
  readonly baseURL = 'http://localhost:5114/api/Booking';
  list: Booking[];

  constructor(private http: HttpClient) { }

  PostBookingDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  PutBookingtDetail() {
    return this.http.put(this.baseURL, this.formData);
  }

  DeleteBooking(id: number) {
    return this.http.delete(`${this.baseURL}/?numBookingID=${id}`);
  }

  GetBookingDetails(): Observable<any> {
    return this.http.get<any>(this.baseURL).pipe();
  }
}
