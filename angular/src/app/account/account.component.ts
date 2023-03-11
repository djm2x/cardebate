import { Component, OnInit, ChangeDetectorRef, Inject } from '@angular/core';
import { routerTransition } from '../utils/animations';
import { MediaMatcher } from '@angular/cdk/layout';
import { OverlayContainer } from '@angular/cdk/overlay';
import { SessionService } from '../shared/session.service';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { NotifyHubService } from '../shared/notify-hub.service';
import { User } from '../shared';
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
  animations: [routerTransition],
})
export class AccountComponent implements OnInit {
  panelOpenState = false;
  mobileQuery: MediaQueryList;
  currentSection = 'section1';
  userImg = '../../assets/picto-logo.png';
  opened = true;
  user = new User();
  idRole = -1;
  isConnected = false;
  constructor(private overlayContainer: OverlayContainer, changeDetectorRef: ChangeDetectorRef
    , media: MediaMatcher, private router: Router, public session: SessionService
    , private notify: NotifyHubService, private route: ActivatedRoute) {

    // define the limite size
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    // mobileQuery.matches is listen for the size
    // wa can now use mobileQuery.matches booleen in the template
    this.mobileQuery.addListener((e: MediaQueryListEvent) => changeDetectorRef.detectChanges());
    this.currentSection = this.router.url.toString();
    //
    // notify.noteHubCnx();
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

  getState(outlet: RouterOutlet) {
    return outlet.activatedRouteData.state;
  }

}


