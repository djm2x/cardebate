import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  o = {
    title: 'yassin mourabit blog',
    description: 'Master en contrôle qualité des médicaments ',
    image: 'https://blog.smartkeyword.io/wp-content/uploads/2018/01/content-marketing.png',
    url: ''
  };
  constructor() {
  }

  ngOnInit(): void { }

}
