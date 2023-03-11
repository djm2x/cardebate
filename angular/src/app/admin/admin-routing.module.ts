import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { DashComponent } from './dash/dash.component';
import { MarqueComponent } from './marque/marque.component';
import { CountryComponent } from './country/country.component';
import { RoleComponent } from './role/role.component';
import { TransmissionComponent } from './transmission/transmission.component';
import { CarburantComponent } from './carburant/carburant.component';
import { UserComponent } from './user/user.component';
import { ModelComponent } from './model/model.component';
import { AdvertComponent } from './advert/advert.component';
import { TypevoitureComponent } from './typevoiture/typevoiture.component';
import { TypeuserComponent } from './typeuser/typeuser.component';

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: AdminComponent,
    children: [
      { path: '', redirectTo: 'dash', pathMatch: 'full' },
      { path: 'dash', component: DashComponent, data: { state: 'dash' } },
      { path: 'marque', component: MarqueComponent, data: { state: 'marque' } },
      { path: 'country', component: CountryComponent, data: { state: 'country' } },
      { path: 'role', component: RoleComponent, data: { state: 'role' } },
      { path: 'transmission', component: TransmissionComponent, data: { state: 'transmission' } },
      { path: 'carburant', component: CarburantComponent, data: { state: 'carburant' } },
      { path: 'user', component: UserComponent, data: { state: 'user' } },
      // { path: 'typeuser', component: TypeuserComponent, data: { state: 'typeuser' } },
      { path: 'model', component: ModelComponent, data: { state: 'model' } },
      { path: 'advert', component: AdvertComponent, data: { state: 'advert' } },
      { path: 'typevoiture', component: TypevoitureComponent, data: { state: 'typevoiture' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
