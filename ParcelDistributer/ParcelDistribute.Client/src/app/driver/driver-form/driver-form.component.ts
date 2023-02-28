import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver.service';
import { NgForm } from '@angular/forms';
import { Driver } from '../driver.model';
import { ToastrService } from 'ngx-toastr';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-driver-form',
  templateUrl: './driver-form.component.html',
  styles: [
  ]
})
export class DriverFormComponent implements OnInit {

  subs = new SubSink();

  constructor(public service: DriverService, private toaster: ToastrService) {}

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    if(this.service.formData.numDriverID == 0 || this.service.formData.numDriverID === undefined)
    this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.PostDriverDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.success('Successfully Saved.', 'Driver Details');
        this.subs.sink = this.service.GetDriverDetails().subscribe(response => {
          this.service.list = response.drivers;
        });
      },
      err => { console.log(err); }
    )
  }

  updateRecord(form: NgForm) {
    this.service.PutDrivertDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.warning('Successfully Updated.', 'Driver Details');
        this.subs.sink = this.service.GetDriverDetails().subscribe(response => {
          this.service.list = response.drivers;
        });
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Driver();
  }
}
