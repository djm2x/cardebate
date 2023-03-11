import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { PrebootModule } from 'preboot';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TransferHttpCacheModule, StateTransferInitializerModule } from '@nguniversal/common';
import { BrowserModule } from '@angular/platform-browser';
@NgModule({
  imports: [
    AppModule,
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    ServerModule,
    ModuleMapLoaderModule, // <-- *Important* to have lazy-loaded routes work
    NoopAnimationsModule,
    // PrebootModule.withConfig({ appRoot: 'app-root' }),
    TransferHttpCacheModule, // still needs fixes for 5.0
    //   Leave this commented out for now, as it breaks Server-renders
    //   Looking into fixes for this! - @MarkPieszak
    // StateTransferInitializerModule // <-- broken for the time-being with ASP.NET
  ],
  // providers: [
  //   {
  //       provide: HTTP_INTERCEPTORS,
  //       useClass: ServerSideRequestInterceptor,
  //       multi: true,
  //   },
  // ]
  bootstrap: [AppComponent],
})
export class AppServerModule {
  // Make sure to define this an arrow function to keep the lexical scope
  ngOnBootstrap = () => {
    console.log('bootstrapped');
  }
}
