import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashComponent } from './dash/dash.component';
import { MatModule } from '../mat.module';
import { LoaderModule } from '../utils/loader/loader.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MarqueComponent } from './marque/marque.component';
import { CountryComponent } from './country/country.component';
import { AdvertComponent } from './advert/advert.component';
import { CarburantComponent } from './carburant/carburant.component';
import { RoleComponent } from './role/role.component';
import { TransmissionComponent } from './transmission/transmission.component';
import { TypevoitureComponent } from './typevoiture/typevoiture.component';
import { UserComponent } from './user/user.component';
import { ModelComponent } from './model/model.component';
import { UserRoleComponent } from './user-role/user-role.component';
import { TypeuserComponent } from './typeuser/typeuser.component';
import { ModelImageComponent } from './model-image/model-image.component';

@NgModule({
  declarations: [
    AdminComponent,
    DashComponent,
    MarqueComponent,
    CountryComponent,
    AdvertComponent,
    CarburantComponent,
    RoleComponent,
    TransmissionComponent,
    TypevoitureComponent,
    UserComponent,
    ModelComponent,
    UserRoleComponent,
    TypeuserComponent,
    ModelImageComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatModule,
    LoaderModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UserRoleComponent,
    ModelImageComponent
  ],
})
export class AdminModule { }
