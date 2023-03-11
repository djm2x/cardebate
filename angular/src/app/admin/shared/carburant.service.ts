import { HttpClient } from '@angular/common/http';
import { SuperService } from './super.service';
import { Injectable, Inject } from '@angular/core';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable({
  providedIn: 'root'
})
export class CarburantService extends SuperService {

  constructor() {
    super();
    this.controller = 'carburant';
  }
}

