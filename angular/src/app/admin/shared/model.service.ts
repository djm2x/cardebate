import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class ModelService extends SuperService {
  constructor() {
    super();
    this.controller = 'model';
  }

  compare(id1, id2) {
    return this.http.get(`${this.url}/${this.controller}/compare/${id1}/${id2}`);
  }

  getPageForModel(idMarque, startIndex = 0, pageSize = 6) {
    return this.http.get(
      `${this.url}/${this.controller}/GetPageForModel/${idMarque}/${startIndex}/${pageSize}`
      );
  }

  getAllForModel(idMarque) {
    return this.http.get(`${this.url}/${this.controller}/GetAllForModel/${idMarque}`);
  }
}

