import { SuperService } from './super.service';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends SuperService {

  constructor() {
    super();
    this.controller = 'country';
  }
}
