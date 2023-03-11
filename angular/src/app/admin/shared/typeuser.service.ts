import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { SuperService } from './super.service';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable({
  providedIn: 'root'
})
export class TypeuserService extends SuperService {
  constructor() {
    super();
    this.controller = 'typeuser';
  }
}
