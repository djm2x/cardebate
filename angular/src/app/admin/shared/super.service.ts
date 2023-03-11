import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Inject, Injectable } from '@angular/core';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';
import { InjectService } from '../../inject.service';

// const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})
export class SuperService implements ISuperService {
  // public url = `${this.originUrl}/api`; //  || environment.apiUrl;
  public controller = '';
  // @Inject(HttpClient) protected http: HttpClient;
  protected http = InjectService.injector.get(HttpClient);
  protected baseUrl = InjectService.injector.get('BASE_URL');
  constructor() {
    console.log(`asp: ${this.url}`);
  }

  get url() {
    return this.baseUrl !== 'http://localhost:4200' ? `${this.baseUrl}/api` : environment.apiUrl;
    // return `${this.baseUrl}/api`;
  }

  getList(startIndex = 0, pageSize = 6) {
    return this.http.get(`${this.url}/${this.controller}/GetList/${startIndex}/${pageSize}`);
  }
  get = (controller = this.controller) => this.http.get(`${this.url}/${controller}/get`);
  getOne = (id, controller = this.controller) => this.http.get(`${this.url}/${controller}/get/${id}`);
  post = (o) => this.http.post(`${this.url}/${this.controller}/post`, o);
  put = (o) => this.http.put(`${this.url}/${this.controller}/put/${o.id}`, o);
  delete = (id) => this.http.delete(`${this.url}/${this.controller}/delete/${id}`);
}

interface ISuperService {
  getList(startIndex, pageSize): Observable<any>;
  get(controller: string);
  getOne(id, controller: string);
  post(o);
  put(o);
  delete(id);
}
