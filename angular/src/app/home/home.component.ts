import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { SessionService, User } from '../shared';
import { MediaMatcher } from '@angular/cdk/layout';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  mobileQuery: MediaQueryList;
  user = new User();
  idRole = -1;
  isConnected = false;
  constructor(private session: SessionService, changeDetectorRef: ChangeDetectorRef
    , media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this.mobileQuery.addListener((e: MediaQueryListEvent) => changeDetectorRef.detectChanges());
  }

  ngOnInit() {
    if (this.session.isSignedIn) {
      this.isConnected = true;
      this.user = this.session.user;
    }
    this.session.notif.subscribe(
      r => {
        this.isConnected = r.is;
        this.user = r.user;
        console.log(r);
      }
    );
  }

  disconnect() {
    this.session.doSignOut();
  }

}
