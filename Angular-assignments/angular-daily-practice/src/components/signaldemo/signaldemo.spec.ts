import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Signaldemo } from './signaldemo';

describe('Signaldemo', () => {
  let component: Signaldemo;
  let fixture: ComponentFixture<Signaldemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Signaldemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Signaldemo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
