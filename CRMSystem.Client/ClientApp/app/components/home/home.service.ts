import { Injectable } from '@angular/core'
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { ProductData } from './product.data';

var url = 'http://localhost:57087/api/Products/'

@Injectable()
export class HomeService {
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
 