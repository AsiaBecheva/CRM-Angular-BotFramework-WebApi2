import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './customers/customer.component';
import { ProductComponent } from './products/product.component';
import { UserComponent } from './users/user.profile.component';
import { SalesComponent } from './sales/sales.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'customers/all', component: CustomerComponent },
    { path: 'products/all', component: ProductComponent },
    { path: 'user', component: UserComponent },
    { path: 'sales', component: SalesComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class CrmRouteModule {

}


