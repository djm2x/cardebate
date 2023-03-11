import { Component, OnInit, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TableDataSource } from '../shared/table-datasource';
import { User } from '../../../app/shared/models';
import { MatPaginator, MatDialog } from '@angular/material';
import { UserService } from '../shared/user.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { UserRoleComponent } from '../user-role/user-role.component';
import { TypeuserService } from '../shared/typeuser.service';
import { SuperService } from '../shared/super.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class UserComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  // @ViewChild(MatSort) sort: MatSort;
  update: EventEmitter<any> = new EventEmitter();
  dataSource = [];
  dataSourceHandler: TableDataSource;
  //
  columnDefs = [
    { columnDef: 'fullName', headName: 'fullName' },
    { columnDef: 'email', headName: 'email' },
    { columnDef: 'tel', headName: 'tel' },
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
  o = new User();
  expandedElement: User | null;
  isEdit = false;
  // typeusers = this.superS.get('typeuser');
  constructor(private service: UserService, private superS: SuperService
    , private fb: FormBuilder, public dialog: MatDialog) { }

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
      fullName: [this.o.fullName, Validators.required],
      imageUrl: [this.o.imageUrl, Validators.required],
      // idTypeUser: [this.o.idTypeUser, Validators.required],
      address: [this.o.address, Validators.required],
      email: [this.o.email, [Validators.email, Validators.required]],
      password: [this.o.password, Validators.required],
      tel: [this.o.tel, Validators.required],
    });
  }

  resetForm() {
    this.o = new User();
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
    const dialogRef = this.dialog.open(UserRoleComponent, {
      width: '750px',
      disableClose: true,
      data: { user: o }
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

