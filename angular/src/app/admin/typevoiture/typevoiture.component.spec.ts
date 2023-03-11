import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TypevoitureComponent } from './typevoiture.component';

describe('TypevoitureComponent', () => {
  let component: TypevoitureComponent;
  let fixture: ComponentFixture<TypevoitureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TypevoitureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TypevoitureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
