import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Formdemo } from './formdemo';

describe('Formdemo', () => {
  let component: Formdemo;
  let fixture: ComponentFixture<Formdemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Formdemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Formdemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
