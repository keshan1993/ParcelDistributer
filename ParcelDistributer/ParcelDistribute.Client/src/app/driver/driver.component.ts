import { Component, OnInit  } from '@angular/core';
import { Driver } from './driver.model';
import { DriverService } from './driver.service';
import { SubSink } from 'subsink';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-driver',
  templateUrl: './driver.component.html',
  styles: [
  ]
})
export class DriverComponent implements OnInit {

  subs = new SubSink();

  constructor(public service: DriverService, private toaster: ToastrService) { }

  ngOnInit() {
    this.subs.sink = this.service.GetDriverDetails().subscribe(response => {
      this.service.list = response.drivers;
    });
  }

  populateForm(selectedRecord: Driver) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(numDriverID: number) {
    if (confirm('Are You Sure To Delete This Driver ?')) {
      this.service.DeleteDriver(numDriverID)
        .subscribe(res => {
          this.subs.sink = this.service.GetDriverDetails().subscribe(response => {
            this.service.list = response.drivers;
          });
          this.toaster.error('Successfully Deleted.', 'Driver Details');
        },
        err => { console.log(err); })
    }
  }
}
