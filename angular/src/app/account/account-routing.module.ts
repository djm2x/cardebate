import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './account.component';
import { DashComponent } from './dash/dash.component';
import { AddComponent } from './add/add.component';
import { CarComponent } from './car/car.component';
import { AdvertComponent } from './advert/advert.component';


const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: AccountComponent,
    children: [
      { path: '', redirectTo: 'dash', pathMatch: 'full' },
      { path: 'dash', component: DashComponent, data: { state: 'dash' } },
      { path: 'add', component: AddComponent, data: { state: 'add' } },
      { path: 'car', component: CarComponent, data: { state: 'car' } },
      { path: 'advert', component: AdvertComponent, data: { state: 'advert' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
