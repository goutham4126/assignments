import { Component } from '@angular/core';
import { Description } from '../description/description';
import { InsuranceProfiles } from '../insurance-profiles/insurance-profiles';
import { WelcomeBanner } from '../welcome-banner/welcome-banner';

@Component({
  selector: 'app-home',
  imports: [Description,InsuranceProfiles,WelcomeBanner],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

}
