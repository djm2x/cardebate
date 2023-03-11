import { Component, OnInit, EventEmitter, ViewChild, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TableDataSource } from '../shared/table-datasource';
import { UserRole, User } from '../../../app/shared/models';
import { MatPaginator, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { UserRoleService } from '../shared/user-role.service';
import { SuperService } from '../shared/super.service';

@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.scss']
})
export class UserRoleComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  // @ViewChild(MatSort) sort: MatSort;
  update: EventEmitter<any> = new EventEmitter();
  dataSource = [];
  dataSourceHandler: TableDataSource;
  //
  columnDefs = [
    { columnDef: 'user', headName: 'user' },
    { columnDef: 'role', headName: 'role' },
    { columnDef: 'option', headName: 'Option' },
  ];

  i = 0;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
    this.columnDefs[this.i++].columnDef,
  ];
  //
  public myForm: FormGroup;
  o = new UserRole();
  isEdit = false;
  roles = this.superS.get('role');
  constructor(private service: UserRoleService, private superS: SuperService
    , private fb: FormBuilder
    , @Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<any>) {
      //
    this.o.user = (this.data.user as User) ;
    this.service.idUser = this.o.user.id;
    console.log(this.o.idUser, this.service.idUser);
  }

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
      idUser: this.o.user.id,
      idRole: [this.o.idRole, Validators.required],
    });
  }

  resetForm() {
    this.o = new UserRole();
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
    this.service.remove(o.idUser, o.idRole).subscribe(
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

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(): void {
    this.dialogRef.close('ok');
  }
}



