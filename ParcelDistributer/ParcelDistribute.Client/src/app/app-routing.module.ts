import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingComponent } from './booking/booking.component';
import { CustomerComponent } from './customer/customer.component';
import { DriverComponent } from './driver/driver.component';
import { InvoiceComponent } from './invoice/invoice.component';

const routes: Routes = [
  { path: '', redirectTo: "Customers", pathMatch: "full" },
  { path: 'Drivers', component: DriverComponent },
  { path: 'Customers', component: CustomerComponent },
  { path: 'Bookings', component: BookingComponent },
  { path: 'Invoices', component: InvoiceComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [DriverComponent, CustomerComponent, BookingComponent, InvoiceComponent]
