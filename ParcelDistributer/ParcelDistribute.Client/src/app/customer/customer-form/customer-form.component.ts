import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { NgForm } from '@angular/forms';
import { Customer } from '../customer.model';
import { ToastrService } from 'ngx-toastr';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styles: [
  ]
})
export class CustomerFormComponent implements OnInit {

  subs = new SubSink();

  constructor(public service: CustomerService, private toaster: ToastrService) {}

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    if(this.service.formData.numCustomerID == 0 || this.service.formData.numCustomerID === undefined)
    this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.PostCustomerDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.success('Successfully Saved.', 'Customer Details');
        this.subs.sink = this.service.GetCustomerDetails().subscribe(response => {
          this.service.list = response.customers;
        });
      },
      err => { console.log(err); }
    )
  }

  updateRecord(form: NgForm) {
    this.service.PutCustomertDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.warning('Successfully Updated.', 'Customer Details');
        this.subs.sink = this.service.GetCustomerDetails().subscribe(response => {
          this.service.list = response.customers;
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Customer();
  }
}
