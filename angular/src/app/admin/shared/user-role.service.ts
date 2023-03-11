import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { SuperService } from './super.service';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService extends SuperService {
  // hack this is not good implementation
  public idUser = 0;
  constructor() {
    super();
    this.controller = 'userrole';
  }

  getList(startIndex = 0, pageSize = 6) {
    return this.getByUser(this.idUser, startIndex, pageSize);
  }

  getByUser(idUser, startIndex, pageSize) {
    console.log(idUser, startIndex, pageSize);
    return this.http.get(`${this.url}/${this.controller}/getByUser/${idUser}/${startIndex}/${pageSize}`);
  }

  remove = (idUser, idRole) => {
    return this.http.delete(`${this.url}/${this.controller}/delete/${idUser}/${idRole}`);
  }
}

