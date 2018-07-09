import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { ProductData } from './product.data';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit{
    private productData: ProductData | undefined;

    constructor(private homeservice: HomeService) { }

    ngOnInit(): void {
        this.homeservice
            .getData()
            .then(prodData => {
                console.log(prodData)
                this.productData = prodData
            })
    }
}
