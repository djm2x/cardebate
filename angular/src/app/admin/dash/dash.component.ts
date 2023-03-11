import { Component, OnInit } from '@angular/core';
import { SuperService } from '../shared/super.service';

@Component({
  selector: 'app-dash',
  templateUrl: './dash.component.html',
  styleUrls: ['./dash.component.scss']
})
export class DashComponent implements OnInit {
  o = this.superS.get('country');
  o2 = this.superS.get('model');
  o3 = {};
  constructor(private superS: SuperService) { }

  ngOnInit() {
    this.superS.get('marque').subscribe(
      r => this.o3 = r as any
    );
  }

}
