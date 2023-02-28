import { Component, OnInit  } from '@angular/core';
import { Booking } from '../booking/booking.model';
import { BookingService } from '../booking/booking.service';
import { SubSink } from 'subsink';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styles: [
  ]
})
export class InvoiceComponent implements OnInit {

  subs = new SubSink();

  constructor(public service: BookingService, private toaster: ToastrService) { }

  ngOnInit() {
    this.subs.sink = this.service.GetBookingDetails().subscribe(response => {
      this.service.list = response.bookings;
    });
  }
}
