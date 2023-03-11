import { Component, OnInit, ViewChild } from '@angular/core';
import { MetaService } from '../../shared/meta.service';
import { SuperService } from '../../admin/shared/super.service';
import { Marque } from '../../shared/models';
import { MatPaginator } from '@angular/material';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {
  titre = 'Car debate';
  img = '../../../assets/intro.jpg';
  list = [new Marque(), new Marque(), new Marque()
    , new Marque(), new Marque(), new Marque()];
  //
  @ViewChild(MatPaginator) paginator: MatPaginator;
  resultsLength = 0;
  o2 = {
    title: 'car debate website',
    description: 'all cars and their carateriqtics and compariason between them',
    image: `https://static1.squarespace.com/static/58c1632ad1758ed406685f25/t/5aac74fe88251b56302cc2c4/1521251592106/toy+cars.jpg`,
    url: ''
  };
  constructor(private service: SuperService, public meta: MetaService) {

  }

  ngOnInit() {
    this.service.controller = 'marque';
    this.meta.updateMeta(this.o2.title, this.o2.description, this.o2.image, this.o2.url);
    this.getAll();
    this.setPagination();
  }

  // isAutoriseToUpdate() {
  //   if (this.session.isAdmin()) {
  //     return true;
  //   }
  //   return false;
  // }

  public setPagination() {
    // this.paginator.pageIndex = 0;
    this.paginator.page.subscribe(info => {
      const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
      // console.log(this.paginator.pageIndex , this.paginator.pageSize);
      this.getAll(startIndex, this.paginator.pageSize);
    });
  }

  // get all recette
  getAll(startIndex = 0, pageSize = 6) {
    // console.log('>>>>>>>>>>>>>>');
    this.service.getList(startIndex, pageSize).subscribe(
      (r: any) => {
        console.log(r);
        if (r.list.length !== 0) {
          this.list = r.list;
          this.resultsLength = r.count;
        }
      }
    );
  }

}
