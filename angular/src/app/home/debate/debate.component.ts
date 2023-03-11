import { Component, OnInit, Injectable } from '@angular/core';
import { ModelService } from '../../admin/shared/model.service';
import { ActivatedRoute, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Model } from '../../shared';
import { Subject, Observable } from 'rxjs';

@Component({
  selector: 'app-debate',
  templateUrl: './debate.component.html',
  styleUrls: ['./debate.component.scss']
})
export class DebateComponent implements OnInit {
  mainModel = new Model();
  modelToCompare = new Model();
  // public eventsSubject1 = new Subject<any>();
  // public eventsSubject2 = new Subject<any>();

  constructor(private service: ModelService, private route: ActivatedRoute) { }

  async ngOnInit() {
    this.route.data.subscribe(
      r => {
        console.log(r['mydata']);
        this.mainModel = r['mydata'].model1;
        this.modelToCompare = r['mydata'].model2;
      }
    );
    // const params: { id1: string, id2: string } = (this.route.snapshot.params) as any;
    // console.log(params.id1);
    // this.firstModel(params.id1);
    // this.secondModel(params.id2);
    // const model1 = await this.service.getOne(params.id1).toPromise();
    // const model2 = await this.service.getOne(params.id2).toPromise();
    // this.eventsSubject1.next({ model1, model2 });
    // this.eventsSubject2.next({ model2, model1 });
  }

  firstModel(id) {
    this.service.getOne(id).subscribe(
      (r: any) => {
        this.mainModel = r;
      }
    );
  }

  secondModel(id) {
    this.service.getOne(id).subscribe(
      (r: any) => {
        console.log(r);
        this.modelToCompare = r;
      }
    );
  }

}

@Injectable({
  providedIn: 'root'
})
export class DebateResolve implements Resolve<Observable<any>> {

  constructor(private service: ModelService, ) { }

  public resolve(r: ActivatedRouteSnapshot) {
    // console.log(route.paramMap.get('id'));
    return this.service.compare(r.paramMap.get('id1'), r.paramMap.get('id2'));
  }

}
