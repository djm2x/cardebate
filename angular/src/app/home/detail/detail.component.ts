import { Component, OnInit, EventEmitter, Injectable } from '@angular/core';
import { ActivatedRoute, Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { ModelService } from '../../admin/shared/model.service';
import { MetaService } from '../../shared/meta.service';
import { Model, ModelImg } from '../../shared/models';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MarqueService } from '../../admin/shared/marque.service';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  mainModel = new Model();
  modelToCompare: Model;
  myForm: FormGroup;
  marques = this.serviceMrq.get();
  models: Model[] = [];
  public eventsSubject = new Subject<any>();
  public eventsSubject2 = new Subject<any>();
  constructor(private route: ActivatedRoute, public meta: MetaService
    , private service: ModelService, public serviceMrq: MarqueService
    , private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.getObjectFromRouteResolver();
    this.createForm();
    // setTimeout(() => this.listAsync.next(this.images), 1);
    // const id = this.route.snapshot.paramMap.get('id');
    // this.service.getOne(id).subscribe(
    //   (r: any) => {
    //     console.log(r);
    //     this.mainModel = r;
    //     this.images = this.mainModel.modelImgs;
    //     // this.listAsync.next(this.o.modelImgs);
    //   }
    // );
  }

  getObjectFromRouteResolver() {
    this.route.data.subscribe(
      r => {
        console.log(r['mydata']);
        this.mainModel = r['mydata'];
      }
    );
  }

  createForm() {
    this.myForm = this.fb.group({
      idMarque: [null, Validators.required],
      idModel: [{ value: '', disabled: true }, Validators.required],
    });
  }

  compare(o: FormGroup) {
    const idModelFirst = this.mainModel.id;
    const idModelSecond = o.value.idModel;
    console.log(idModelFirst, idModelSecond);
    this.router.navigate(['home/debate', idModelFirst, idModelSecond]);
  }

  // modelChange(idModel) {
  //   this.modelToCompare = this.models.find(e => e.id === idModel);
  //   this.eventsSubject.next({ mainModel: this.mainModel, modelToCompare: this.modelToCompare });
  //   this.eventsSubject2.next({ mainModel: this.modelToCompare, modelToCompare: this.mainModel });
  // }

  marqueChange(idMarque: number) {
    this.service.getAllForModel(idMarque).subscribe(r => this.models = r as any);
    this.myForm.get('idModel').enable();
  }

}

@Injectable({
  providedIn: 'root'
})
export class MyResolve implements Resolve<Observable<any>> {

  constructor(private service: ModelService) { }

  public resolve(route: ActivatedRouteSnapshot) {
    // console.log(route.paramMap.get('id'));
    return this.service.getOne(route.paramMap.get('id')) as Observable<any>;
  }

}
