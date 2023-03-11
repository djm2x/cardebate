import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User, SessionService } from '../../shared';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public myForm: FormGroup;
  model: LoginDto = new LoginDto();
  // o = new User();
  o = {
    idTypeUser: '1',
    fullName: 'm2x',
    email: 'sa@angular.io',
    password: '123'
  };

  hide = true;
  msg = '';
  isNew = false;
  constructor(private service: AuthService, private session: SessionService
    , private fb: FormBuilder, public router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.myForm = this.fb.group({
      idTypeUser: [this.o.idTypeUser, [this.isNew ? Validators.required : Validators.minLength(0)]],
      fullName: [this.o.fullName, [this.isNew ? Validators.required : Validators.minLength(0)]],
      email: [this.o.email, [Validators.required, Validators.email]],
      password: [this.o.password, Validators.required],
      passwordConfirme: [this.o.password, this.isNew ? Validators.required : Validators.minLength(0)],
    });
  }

  submit(myForm: FormGroup) {
    if (!myForm.valid) {
      return;
    }
    // this.login(o.value as User);
    const obj: User = myForm.value;
    const user = {
      idTypeUser: +obj.idTypeUser,
      fullName: obj.fullName,
      email: obj.email,
      password: obj.password
    } as User;
    // console.log(user);
    // return;
    if (this.isNew) {
      this.signin(user);
    } else {
      this.login(user);
    }
  }

  login(o: User) {
    // o.fullName
    this.service.login({ email: o.email, password: o.password }).subscribe(
      (r: { user: User, token: string, idRole: number}) => {
        // this.o = r.user;
        console.log(r);
        this.session.doSignIn(r);
        if (r.idRole === 1) {
          this.router.navigate(['/home/welcome']);
        } else if (r.idRole === 3 || r.idRole === 2) {
          this.router.navigate(['/admin/dash']);
        }
      }
    );
  }

  signin(obj: any) {
    console.log(obj);
    this.service.signin(obj).subscribe(
      (r: any) => {
        console.log(r);
        this.resetForm();
      },
      error => {
        console.log(error);
      }
    );
  }

  resetForm() {
    this.o = {
      idTypeUser: '1',
      fullName: 'm2x',
      email: 'sa@angular.io',
      password: '123'
    };
    this.createForm();
  }
}


interface Res {
  auth: string;
  user: User;
  accessToken: string;
}

class LoginDto {
  fullName = 'm2x';
  login = 'dj@angular.io';
  password = '123';
}

class LoginDto0 {
  email = '';
  password = '';
}

