import { Component, OnInit } from '@angular/core';
import { Booking } from '../booking.model';
import { NgForm } from '@angular/forms';
import { BookingService } from '../booking.service';
import { ToastrService } from 'ngx-toastr';
import { SubSink } from 'subsink';
import { Driver } from 'src/app/driver/driver.model';
import { DriverService } from 'src/app/driver/driver.service';
import { GoodsType } from 'src/app/goodsType/goods-type.model';
import { GoodsTypeService } from 'src/app/goodsType/goods-type.service';
import { Customer } from 'src/app/customer/customer.model';
import { CustomerService } from 'src/app/customer/customer.service';

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styles: [
  ]
})
export class BookingFormComponent implements OnInit {
  customerList!: Customer[];
  driverList!: Driver[];
  goodsTypeList!: GoodsType[];
  subs = new SubSink();

  constructor(public service: BookingService, private toaster: ToastrService, public dservice: DriverService, 
    public gservice: GoodsTypeService, public cservice: CustomerService) {
    this.driverList = new Array<Driver>();
    this.goodsTypeList = new Array<GoodsType>();
    this.customerList = new Array<Customer>();
  }

  ngOnInit(): void {
    // this.loadDriverList();
    this.loadGoodsTypeList();
    this.loadCustomerList();
  }

  loadCustomerList() {
    this.subs.sink = this.cservice.GetCustomerDetails().subscribe(response => {
      this.customerList = response.customers;
    });
  }

  // loadDriverList() {
  //   this.subs.sink = this.dservice.GetDriverDetails().subscribe(response => {
  //     this.driverList = response.drivers;
  //   });
  // }

  loadAvailableDriverList(event: any) {

    var timestamp = Date.parse(event.target.value);
    if (isNaN(timestamp) == false) {
      this.subs.sink = this.dservice.GetAvailableDrivers(event.target.value).subscribe(response => {
        this.driverList = response.drivers;
      });
    }
  }

  loadGoodsTypeList() {
    this.subs.sink = this.gservice.GetGoodsTypeDetails().subscribe(response => {
      this.goodsTypeList = response.goodsTypes;
    });
  }
  
  onSubmit(form: NgForm){
    if(this.service.formData.numBookingID == 0 || this.service.formData.numBookingID === undefined)
    this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.PostBookingDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.success('Successfully Saved.', 'Booking Details');
        this.subs.sink = this.service.GetBookingDetails().subscribe(response => {
          this.service.list = response.bookings;
        });
      },
      err => { console.log(err); }
    )
  }

  updateRecord(form: NgForm) {
    this.service.PutBookingtDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.warning('Successfully Updated.', 'Booking Details');
        this.subs.sink = this.service.GetBookingDetails().subscribe(response => {
          this.service.list = response.bookings;
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Booking();
  }
}
