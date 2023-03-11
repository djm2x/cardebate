import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SuperService } from '../admin/shared/super.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends SuperService {

  constructor() {
    super();
    this.controller = 'user';
   }

  login(o) {
    return this.http.post(`${this.url}/${this.controller}/login`, o);
  }

  signin(o) {
    return this.http.post(`${this.url}/${this.controller}/post`, o);
  }
}
