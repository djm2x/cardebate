import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MetaService } from '../../shared/meta.service';
import { SuperService } from '../../admin/shared/super.service';
import { ModelService } from '../../admin/shared/model.service';
import { MatPaginator } from '@angular/material';
import { Model } from '../../shared/models';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.scss']
})
export class ModelComponent implements OnInit {
  list = [];
  //
  @ViewChild(MatPaginator) paginator: MatPaginator;
  resultsLength = 0;
  idModel = 0;
  test = [];
  // public listAsync: EventEmitter<Model[]> = new EventEmitter();

  constructor(private route: ActivatedRoute, public meta: MetaService
    , private service: ModelService) { }

  ngOnInit() {
    // setTimeout(() => this.listAsync.next(this.list), 1);
    this.idModel = +this.route.snapshot.paramMap.get('id');
    this.getAll();
  }

  // public setPagination() {
  //   // this.paginator.pageIndex = 0;
  //   this.paginator.page.subscribe(info => {
  //     const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
  //     // console.log(this.paginator.pageIndex , this.paginator.pageSize);
  //     this.getAll(startIndex, this.paginator.pageSize);
  //   });
  // }

  getAll(startIndex = 0, pageSize = 6) {
    console.log(this.idModel, startIndex, pageSize);
    this.service.getPageForModel(this.idModel, startIndex, pageSize).subscribe(
      (r: any) => {
        console.log(r);
        if (r.list.length !== 0) {
          this.list = r.list;
          this.test = r.list;
          // setTimeout(() => this.listAsync.next(r.list), 100);
          this.resultsLength = r.count;
        }
      }
    );
  }

}
