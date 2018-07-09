import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from './product.service';
import { ProductComponent } from './product.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [ProductComponent],
    providers: [ProductService],
    imports: [FormsModule, CommonModule]
})
export class ProductModule {

}
