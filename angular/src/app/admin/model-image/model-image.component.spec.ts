import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelImageComponent } from './model-image.component';

describe('ModelImageComponent', () => {
  let component: ModelImageComponent;
  let fixture: ComponentFixture<ModelImageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelImageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
