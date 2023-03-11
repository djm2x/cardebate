import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { ModelComponent } from './model/model.component';
import { DetailComponent, MyResolve } from './detail/detail.component';
import { DebateComponent, DebateResolve } from './debate/debate.component';

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: HomeComponent,
    children: [
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: 'welcome', component: WelcomeComponent, data: { state: 'welcome' } },
      { path: 'model/:id', component: ModelComponent, data: { state: 'model' } },
      { path: 'detail/:id', component: DetailComponent, resolve: { mydata: MyResolve }, data: { state: 'detail' } },
      { path: 'debate/:id1/:id2', component: DebateComponent, resolve: { mydata: DebateResolve }, data: { state: 'debate' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
