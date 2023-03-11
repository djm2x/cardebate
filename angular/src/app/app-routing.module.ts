import { NgModule, Injectable } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { MyGuard } from './shared/my.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'home', loadChildren: './home/home.module#HomeModule', data: { preload: true, delay: false }},
  { path: 'admin', loadChildren: './admin/admin.module#AdminModule', canActivate: [MyGuard], data: { preload: true, delay: false }},
  { path: 'auth', loadChildren: './auth/auth.module#AuthModule', data: { preload: false, delay: false }},
  { path: 'account', loadChildren: './account/account.module#AccountModule', data: { preload: false, delay: false }},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules
    }),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
