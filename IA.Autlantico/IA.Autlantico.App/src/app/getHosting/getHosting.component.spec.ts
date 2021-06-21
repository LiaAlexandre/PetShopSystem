/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GetHostingComponent } from './getHosting.component';

describe('GetHostingComponent', () => {
  let component: GetHostingComponent;
  let fixture: ComponentFixture<GetHostingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetHostingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetHostingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
