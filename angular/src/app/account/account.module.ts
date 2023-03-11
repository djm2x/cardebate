import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashComponent } from './dash/dash.component';
import { AccountComponent } from './account.component';
import { AccountRoutingModule } from './account-routing.module';
import { MatModule } from '../mat.module';
import { LoaderModule } from '../utils/loader/loader.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdvertComponent } from './advert/advert.component';
import { CarComponent } from './car/car.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [DashComponent, AccountComponent, AdvertComponent, CarComponent, AddComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MatModule,
    LoaderModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AccountModule { }
