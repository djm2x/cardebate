import { Injectable } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';
import { environment } from '../../environments/environment';

const URL = environment.hubUrl;
@Injectable({
  providedIn: 'root'
})
export class MetaService {

  constructor(private title: Title, private meta: Meta) { }

  setMeta(title, description, image, url, robots = 'index, follow') {
    this.title.setTitle(title);
    this.meta.addTag({ name: 'description', content: description });

    this.meta.addTag({ name: 'og:title', property: 'og:title', content: title });
    this.meta.addTag({ name: 'og:description', property: 'og:description', content: description });
    this.meta.addTag({ name: 'og:image', property: 'og:image', content: image });
    this.meta.addTag({ name: 'og:url', property: 'og:url', content: URL + url });

    this.meta.addTag({ name: 'robots', content: robots }); // noindex or none
  }

  updateMeta(title, description, image, url, robots = 'index, follow') {
    this.title.setTitle(title);
    this.meta.updateTag({ name: 'description', content: description });

    this.meta.updateTag({ name: 'og:title', property: 'og:title', content: title });
    this.meta.updateTag({ name: 'og:description', property: 'og:description', content: description });
    this.meta.updateTag({ name: 'og:image', property: 'og:image', content: image });
    this.meta.updateTag({ name: 'og:url', property: 'og:url', content: URL + url });

    this.meta.updateTag({ name: 'robots', content: robots }); // noindex or none
  }
}
