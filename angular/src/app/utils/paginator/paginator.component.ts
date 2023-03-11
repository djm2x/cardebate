import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {
  @Input() length = 0;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @Output() eventToParent = new EventEmitter<MatPaginator>();
  constructor() { }

  ngOnInit() {
    this.paginator.page.subscribe(
      r => this.eventToParent.next(this.paginator)
    );
  }

}
