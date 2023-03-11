import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatModule } from './mat.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ORIGIN_URL, REQUEST } from '@nguniversal/aspnetcore-engine/tokens';
import { ToastrModule } from 'ngx-toastr';
import { LoaderInterceptor } from './utils/loader/loader-interceptor';
import { TransferHttpCacheModule } from '@nguniversal/common';
import { PrebootModule } from 'preboot';
import { InjectService } from './inject.service';

export function getOriginUrl() {
  // console.log('getOriginUrl >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> : ', e);
  // if (typeof window !== 'undefined') {
  //   return window.location.origin;
  // }
  return window.location.origin;
}

export function getRequest() {
  // the Request object only lives on the server
  return { cookie: document.cookie };
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    MatModule,
    // TransferHttpCacheModule,
    // BrowserTransferStateModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: false,
    }),
  ],
  providers: [
    // {
    //   // We need this for our Http calls since they'll be using an ORIGIN_URL provided in main.server
    //   // (Also remember the Server requires Absolute URLs)
    //   provide: ORIGIN_URL,
    //   useFactory: (getOriginUrl)
    // }, {
    //   // The server provides these in main.server
    //   provide: REQUEST,
    //   useFactory: (getRequest)
    // },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private injector: Injector) {    // Create global Service Injector.
    InjectService.injector = this.injector;
  }
 }
