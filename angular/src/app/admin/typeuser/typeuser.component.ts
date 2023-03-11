import { Component, OnInit, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TableDataSource } from '../shared/table-datasource';
import { TypeUser } from '../../../app/shared/models';
import { MatPaginator } from '@angular/material';
import { TypeuserService } from '../shared/typeuser.service';

@Component({
  selector: 'app-typeuser',
  templateUrl: './typeuser.component.html',
  styleUrls: ['./typeuser.component.scss']
})
export class TypeuserComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  // @ViewChild(MatSort) sort: MatSort;
  update: EventEmitter<any> = new EventEmitter();
  dataSource = [];
  dataSourceHandler: TableDataSource;
  //
  columnDefs = [
    { columnDef: 'name', headName: 'name' },
    { columnDef: 'option', headName: 'Option' },
  ];

  i = 0;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
  ];
  //
  public myForm: FormGroup;
  o = new TypeUser();
  isEdit = false;
  constructor(private service: TypeuserService, private fb: FormBuilder) { }

  ngOnInit() {
    this.dataSourceHandler = new TableDataSource(this.paginator, this.service, this.update);
    // data is subscribed now , every event happen the will change and ofcource the datasource for table
    this.dataSourceHandler.methode().subscribe(data => {
      this.dataSource = data;
      // console.log(data);
    });
    this.createForm();
  }

  // reset input
  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      name: [this.o.name, Validators.required],
    });
  }

  resetForm() {
    this.o = new TypeUser();
    this.myForm.reset({
      id: this.o.id,
      name: this.o.name,
    });
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
}




