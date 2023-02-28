import { Component, OnInit  } from '@angular/core';
import { Booking } from './booking.model';
import { BookingService } from './booking.service';
import { SubSink } from 'subsink';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styles: [
  ]
})
export class BookingComponent implements OnInit {

  subs = new SubSink();

  constructor(public service: BookingService, private toaster: ToastrService) { }

  ngOnInit() {
    this.subs.sink = this.service.GetBookingDetails().subscribe(response => {
      this.service.list = response.bookings;
    });
  }

  populateForm(selectedRecord: Booking) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(numBookingID: number) {
    if (confirm('Are You Sure To Delete This Booking ?')) {
      this.service.DeleteBooking(numBookingID)
        .subscribe(res => {
          this.subs.sink = this.service.GetBookingDetails().subscribe(response => {
            this.service.list = response.bookings;
          });
          this.toaster.error('Successfully Deleted.', 'Booking Details');
        },
        err => { console.log(err); })
    }
  }
}
