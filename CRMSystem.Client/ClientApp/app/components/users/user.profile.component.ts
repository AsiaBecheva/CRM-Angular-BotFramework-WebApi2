import { Component } from '@angular/core';
import { CustomerData } from '../customers/customer.data';
import { UserProfileActions } from './user.profile.actions';


enum Status {
    active = 0,
    inactive = 1
}

@Component({
    selector: 'user',
    templateUrl: './user.profile.component.html',
    styleUrls: ['user.profile.component.css']
})
export class UserComponent {
    customer: CustomerData = new CustomerData();
    constructor(private userProfileActions: UserProfileActions) { }

    addCustomer() {
        this.userProfileActions.addCustomer(this.customer)
    }
}