import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';
import { Http } from '@angular/http';
import { CustomerData } from '../customers/customer.data';

var url = 'http://localhost:57087/api/Customers/';

@Injectable()
export class UserProfileService {
    constructor(private http: Http) { }

    setData(customer: CustomerData) {
        return this.http.post(url, customer);
    }
}