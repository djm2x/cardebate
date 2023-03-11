import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselItemElementDirective } from './carousel-item-element.directive';
import { CarouselComponent } from './carousel.component';
import { CarouselItemDirective } from './carousel-item.directive';
import { MatModule } from '../../mat.module';

@NgModule({
  declarations: [
    CarouselComponent,
    CarouselItemDirective,
    CarouselItemElementDirective
  ],
  imports: [
    CommonModule,
    MatModule,
  ],
  exports: [
    CarouselComponent,
    CarouselItemDirective,
    CarouselItemElementDirective
  ]
})
export class CarouselModule { }
