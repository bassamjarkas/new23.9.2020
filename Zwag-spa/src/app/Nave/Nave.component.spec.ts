/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';


import { NaveComponent } from './Nave.component';

describe('NaveComponent', () => {
  let component: NaveComponent;
  let fixture: ComponentFixture<NaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
