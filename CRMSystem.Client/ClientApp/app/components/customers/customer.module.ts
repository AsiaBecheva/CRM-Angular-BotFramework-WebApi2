import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerService } from './customer.service';
import { CustomerComponent } from './customer.component';

@NgModule({
    declarations: [CustomerComponent],
    providers: [CustomerService],
    imports: [FormsModule, CommonModule],
})
export class CustomerModule {

}