import { Component, OnInit, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TableDataSource } from '../shared/table-datasource';
import { Model } from '../../../app/shared/models';
import { MatPaginator, MatDialog } from '@angular/material';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { ModelService } from '../shared/model.service';
import { SuperService } from '../shared/super.service';
import { ModelImageComponent } from '../model-image/model-image.component';
import { SessionService } from '../../shared';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ModelComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  // @ViewChild(MatSort) sort: MatSort;
  update: EventEmitter<any> = new EventEmitter();
  dataSource = [];
  dataSourceHandler: TableDataSource;
  //
  columnDefs = [
    { columnDef: 'id', headName: 'model' },
    { columnDef: 'marque', headName: 'Marque' },
    { columnDef: 'annee', headName: 'Annee' },
    { columnDef: 'option', headName: 'Option' },
  ];

  i = 0;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
  ];
  //
  public myForm: FormGroup;
  o = new Model();
  expandedElement: Model | null;
  isEdit = false;
  marques = this.superS.get('marque');
  carburants = this.superS.get('carburant');
  trans = this.superS.get('transmission');
  types = this.superS.get('typevoiture');
  constructor(private service: ModelService, private superS: SuperService
    , private fb: FormBuilder, public dialog: MatDialog, private session: SessionService) { }

  ngOnInit() {
    this.dataSourceHandler = new TableDataSource(this.paginator, this.service, this.update);
    // data is subscribed now , every event happen the will change and ofcource the datasource for table
    this.dataSourceHandler.methode().subscribe(data => {
      this.dataSource = data;
      // console.log(data);
    });
    this.createForm();
    console.log(this.o.annee);
  }

  async expandedTable(o: Model) {
    if (this.expandedElement === o) {
      this.expandedElement = null;
      return this.expandedElement;
    }
    o.carburant = await this.service.getOne(o.idCarburant, 'carburant').toPromise() as any;
    o.transmission = await this.service.getOne(o.idTransmission, 'transmission').toPromise() as any;
    o.typeVoiture = await this.service.getOne(o.idTypeVoiture, 'typeVoiture').toPromise() as any;

    this.expandedElement = o;
    return this.expandedElement;
  }

  // reset input
  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, Validators.required],
      annee: [this.o.annee, Validators.required],
      puissance: [this.o.puissance, Validators.required],
      reservoir: [this.o.reservoir, Validators.required],
      boiteVitesse: [this.o.boiteVitesse, Validators.required],
      freinageUrgence: [this.o.freinageUrgence, Validators.required],
      vitesseMax: [this.o.vitesseMax, Validators.required],
      poid: [this.o.poid, Validators.required],
      prix: [this.o.prix, Validators.required],
      autonomie: [this.o.autonomie, Validators.required],
      consVille: [this.o.consVille, Validators.required],
      consRoute: [this.o.consRoute, Validators.required],
      consAutoroute: [this.o.consAutoroute, Validators.required],
      cc: [this.o.cc, Validators.required],
      idMarque: [this.o.idMarque, Validators.required],
      idUser: [this.session.user.id, Validators.required],
      idCarburant: [this.o.idCarburant, Validators.required],
      idTransmission: [this.o.idTransmission, Validators.required],
      idTypeVoiture: [this.o.idTypeVoiture, Validators.required],
    });
  }

  resetForm() {
    this.o = new Model();
    this.createForm();
  }

  submit(myForm: FormGroup) {
    const obj: any = myForm.value;
    if (!this.isEdit) {
      this.post(obj);
    } else {
      this.put(obj);
    }
  }

  post(obj: any) {
    console.log(obj);
    this.service.post(obj).subscribe(
      (r: any) => {
        this.update.next(true);
        console.log(r);
        this.resetForm();
      },
      error => {
        console.log(error);
      }
    );
  }

  put(obj: any) {
    this.service.put(obj).subscribe(
      (r: any) => {
        this.update.next(true);
        console.log(r);
        this.isEdit = false;
        this.resetForm();
        this.myForm.get('id').enable();
      },
      error => {
        console.log(error);
      }
    );
  }

  delete(o) {
    this.service.delete(o.id).subscribe(
      (r: any) => {
        this.update.next(true);
      },
      error => {
        console.log(error);
      }
    );
  }

  edit(o: any) {
    console.log(o);
    this.o = o;
    this.isEdit = true;
    this.myForm.get('id').disable();
    this.createForm();
  }

  reset() {
    this.resetForm();
    this.myForm.get('id').enable();
    this.isEdit = false;
  }

  openDialog(o): void {
    const dialogRef = this.dialog.open(ModelImageComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined) {
        console.log('vous avez quittez le dialog');
      } else {
        this.update.next(true);
      }
    });
  }
}

