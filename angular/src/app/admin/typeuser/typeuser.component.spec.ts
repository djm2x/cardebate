import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeuserComponent } from './typeuser.component';

describe('TypeuserComponent', () => {
  let component: TypeuserComponent;
  let fixture: ComponentFixture<TypeuserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TypeuserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TypeuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
