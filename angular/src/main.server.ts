// Polyfills
// import 'es6-promise';
// import 'es6-shim';
import 'zone.js/dist/zone-node';
import 'reflect-metadata';

import { enableProdMode } from '@angular/core';
import { INITIAL_CONFIG } from '@angular/platform-server';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';
// Grab the (Node) server-specific NgModule
import { AppServerModule } from './app/app.server.module';
// ***** The ASPNETCore Angular Engine *****
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript } from '@nguniversal/aspnetcore-engine';
// const { AppModuleNgFactory, LAZY_MODULE_MAP } = require('./app/app.module.server.ngfactory');
const { AppServerModuleNgFactory, LAZY_MODULE_MAP } = require('./app/app.server.module');
import { environment } from './environments/environment';
import { provideModuleMap } from '@nguniversal/module-map-ngfactory-loader';
import { APP_BASE_HREF } from '@angular/common';

if (environment.production) {
  enableProdMode();
}

export default createServerRenderer(params => {
  const setupOptions: IEngineOptions = {
    appSelector: '<app-root></app-root>',
    ngModule: AppServerModule,
    request: params,
    providers: [
      provideModuleMap(LAZY_MODULE_MAP),
      // { provide: APP_BASE_HREF, useValue: params.baseUrl },
      { provide: 'BASE_URL', useValue: params.origin }
    ]
  };

  console.log(params);

  return ngAspnetCoreEngine(setupOptions).then(response => {

    response.globals.transferData = createTransferScript({
      someData: 'data created in main server, url : ' + params.origin,
      fromDotnet: 'data created in HomeController : ' + params.data.thisCameFromDotNET
    });

    return ({
      html: response.html,
      globals: response.globals
    });

  }).catch(e => {
    console.log('ngAspnetCoreEngine : >>');
    console.log(e);
    return e;
  });
});
