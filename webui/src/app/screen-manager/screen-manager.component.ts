import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-screen-manager',
  templateUrl: './screen-manager.component.html',
  styleUrl: './screen-manager.component.scss'
})

export class ScreenManagerComponent {

  constructor(private router: Router) {}

  navigateToMatches() {
    this.router.navigateByUrl('matches');
  }

  navigateToClubes() {
    this.router.navigateByUrl('clubes');
  }
}
