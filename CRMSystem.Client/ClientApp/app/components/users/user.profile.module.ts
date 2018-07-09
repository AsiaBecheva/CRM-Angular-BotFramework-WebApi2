import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserComponent } from './user.profile.component';
import { UserProfileActions } from './user.profile.actions';
import { UserProfileService } from './user.profile.service';

@NgModule({
    declarations: [UserComponent],
    providers: [ UserProfileActions,
        UserProfileService],
    imports: [FormsModule]
})
export class UsersModule {

}