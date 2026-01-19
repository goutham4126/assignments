import { Component } from '@angular/core';

@Component({
  selector: 'app-insurance-profiles',
  imports: [],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
  insuranceProfiles = [
    { name: 'Home', image: 'one.svg' },
    { name: 'Health', image: 'two.svg' },
    { name: 'Business', image: 'three.svg' },
    { name: 'Life', image: 'four.svg' }
  ];
}
