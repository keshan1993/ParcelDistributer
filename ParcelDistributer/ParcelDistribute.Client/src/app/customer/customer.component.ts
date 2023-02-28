import { Component, OnInit  } from '@angular/core';
import { Customer } from './customer.model';
import { CustomerService } from './customer.service';
import { SubSink } from 'subsink';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styles: [
  ]
})
export class CustomerComponent implements OnInit {
  
  subs = new SubSink();

  constructor(public service: CustomerService, private toaster: ToastrService) { }

  ngOnInit() {
    this.subs.sink = this.service.GetCustomerDetails().subscribe(response => {
      this.service.list = response.customers;
    });
  }

  populateForm(selectedRecord: Customer) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(numCustomerID: number) {
    if (confirm('Are You Sure To Delete This Customer ?')) {
      this.service.DeleteCustomer(numCustomerID)
        .subscribe(res => {
          this.subs.sink = this.service.GetCustomerDetails().subscribe(response => {
            this.service.list = response.customers;
          });
          this.toaster.error('Successfully Deleted.', 'Customer Details');
        },
        err => { console.log(err); })
    }
  }
}
