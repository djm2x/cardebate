import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MatModule } from '../mat.module';
import { LoaderModule } from '../utils/loader/loader.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WelcomeComponent } from './welcome/welcome.component';
import { ImgDisplayModule } from '../utils/img-display/img-display.module';
import { ModelComponent } from './model/model.component';
import { DetailComponent } from './detail/detail.component';
import { CarouselModule } from '../utils/carousel/carousel.module';
import { CompareComponent } from './compare/compare.component';
import { DebateComponent } from './debate/debate.component';

@NgModule({
  declarations: [
    HomeComponent,
    WelcomeComponent,
    ModelComponent,
    DetailComponent,
    CompareComponent,
    DebateComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MatModule,
    LoaderModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ImgDisplayModule,
    CarouselModule,
  ]
})
export class HomeModule { }
