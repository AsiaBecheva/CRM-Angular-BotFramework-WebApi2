import { Injectable } from '@angular/core';
import { ProductData } from '../home/product.data';
import 'rxjs/add/operator/toPromise';
import { Http } from '@angular/http';

var url = 'http://localhost:57087/api/Products/';

@Injectable()
export class ProductService {
    constructor(private http: Http) { }

    getData(): Promise<ProductData> {
        return this.http
            .get(url)
            .toPromise()
            .then(resp => resp.json() as ProductData)
            .catch(err => {
                console.log(err);
                return new ProductData()
            })
    }
}