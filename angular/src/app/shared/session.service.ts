import { Injectable, PLATFORM_ID, Inject, EventEmitter } from '@angular/core';
import { User } from './models';
import { isPlatformBrowser, isPlatformServer } from '@angular/common';

const USER = 'USER';
const TOKEN = 'TOKEN';
const ROLE = 'ROLE';
@Injectable({
  providedIn: 'root'
})
export class SessionService {
  public user = new User();
  public token = '';
  public idRole = -1;
  public notif: EventEmitter<{is: boolean, user: User, idRole?: number}> = new EventEmitter();
  constructor(@Inject(PLATFORM_ID) protected platformId: Object) {
    this.getSession();
  }
  // se connecter
  public doSignIn(o: { user: User, token: string, idRole: number }) {
    if (!o.user || !o.token || !o.idRole) {
      return;
    }
    if (isPlatformBrowser(this.platformId)) {
      this.user = o.user;
      this.token = o.token;
      this.idRole = o.idRole;
      localStorage.setItem(USER, btoa(JSON.stringify(this.user)));
      localStorage.setItem(TOKEN, btoa(JSON.stringify(this.token)));
      localStorage.setItem(ROLE, btoa(JSON.stringify(this.idRole)));
      this.notif.next({is: true, user: this.user, idRole: this.idRole});
    }
  }

  // se deconnecter
  public doSignOut(): void {
    // remove user from local storage to log user out
    this.user = new User();
    this.token = '';
      this.idRole = -1;
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem(USER);
      localStorage.removeItem(TOKEN);
      localStorage.removeItem(ROLE);
      this.notif.next({is: false, user: this.user, idRole: this.idRole});
    }
  }

  // this methode is for our auth guard
  get isSignedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      return !!localStorage.getItem(USER);
    }

    if (isPlatformServer(this.platformId)) {
      return true;
    }
  }

  //
  public getSession(): void {
    if (isPlatformBrowser(this.platformId)) {
      try {
        this.user = JSON.parse(atob(localStorage.getItem(USER)));
        this.token = JSON.parse(atob(localStorage.getItem(TOKEN)));
        this.idRole = JSON.parse(atob(localStorage.getItem(ROLE)));
      } catch (error) {
        this.user = new User();
        this.token = '';
        this.idRole = -1;
        console.warn('error localstorage data');
      }

      console.log('token here : ', this.token);
      console.log('idRole here : ', this.idRole);
    }
  }
}

