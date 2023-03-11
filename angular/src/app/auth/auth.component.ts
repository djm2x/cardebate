import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../utils/animations';


@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  animations: [routerTransition],
})
export class AuthComponent implements OnInit {

  constructor() {}

  ngOnInit() {
  }


}
