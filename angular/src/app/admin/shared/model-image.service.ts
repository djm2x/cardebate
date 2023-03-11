import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { SuperService } from './super.service';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable({
  providedIn: 'root'
})
export class ModelImageService extends SuperService {
  // hack this is not good implementation
  public idModel = '';
  constructor() {
    super();
    this.controller = 'modelImg';
  }

  getList(startIndex = 0, pageSize = 6) {
    return this.GetPageForModelImg(this.idModel, startIndex, pageSize);
  }

  GetPageForModelImg(idModel, startIndex, pageSize) {
    // console.log(idModel, startIndex, pageSize);
    return this.http.get(`${this.url}/${this.controller}/GetPageForModelImg/${idModel}/${startIndex}/${pageSize}`);
  }
}

