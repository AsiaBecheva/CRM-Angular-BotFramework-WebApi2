import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { CustomerData } from './customer.data';
import { ProductData } from '../home/product.data';
import 'rxjs/add/operator/toPromise';

var urlCustomers = 'http://localhost:57087/api/Customers/'
var urlProducts = 'http://localhost:57087/api/Products/'

@Injectable()
export class CustomerService {

    constructor(private http: Http) { }

    getData(): Promise<Array<CustomerData>> {
        return this.http
            .get(urlCustomers)
            .toPromise()
            .then(resp => resp.json() as Array<CustomerData>)
            .catch(err => {
                console.log(err);
                return []
            });
    }

    getProductsData(customerId: number) {
        return this.http
            .get(urlProducts + customerId);
    }
}
