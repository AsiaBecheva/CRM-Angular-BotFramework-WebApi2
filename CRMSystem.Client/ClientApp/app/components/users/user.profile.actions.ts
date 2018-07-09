import { Injectable } from '@angular/core';
import { UserProfileService } from './user.profile.service';
import { CustomerData } from '../customers/customer.data';
import { Router } from '@angular/router';

@Injectable()
export class UserProfileActions {
    constructor(private userProfileService: UserProfileService, private router: Router) { }

    addCustomer(customer: CustomerData) {
        this.userProfileService
            .setData(customer)
            .subscribe(respoce => {
                this.router.navigate(['/customers/all']);
            })
    }
}
