import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeService } from './home.service';
import { HomeComponent } from './home.component';

@NgModule({
    declarations: [HomeComponent],
    providers: [HomeService],
    imports: [FormsModule],
})
export class HomeModule {

}