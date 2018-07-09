import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { ProductData } from '../home/product.data';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
    public productData: ProductData | undefined;

    constructor(private productService: ProductService) { }
    
    ngOnInit(): void {
        this.productService
            .getData()
            .then(prodData => {
                console.log(prodData);
                this.productData = prodData;
            })
    }
}

