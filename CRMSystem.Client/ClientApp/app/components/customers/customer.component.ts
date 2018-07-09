import { Component, OnInit } from '@angular/core';
import { CustomerData } from './customer.data';
import { ProductData } from '../home/product.data';
import { CustomerService } from './customer.service';
import { Router } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})
export class CustomerComponent implements OnInit {
    customerData: Array<CustomerData> | undefined;
    productData: Array<ProductData> | undefined;

    constructor(private customerService: CustomerService, private router: Router) { }

    ngOnInit(): void {
        this.customerService
            .getData()
            .then(custData => {
                this.customerData = custData;
            })
    }

    getProducts(id: number) {
        this.customerService
            .getProductsData(id)
            .subscribe(resp => {
                console.log(resp);
                this.router.navigate(['/products/all']);
            })
    }
}

