import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SessionService } from '../services/session.service';
import { LoginDialogComponent } from '../session/login-dialog/login-dialog.component';
import { RegisterDialogComponent } from '../session/register-dialog/register-dialog.component';

@Component({
  selector: 'app-screen-manager',
  templateUrl: './screen-manager.component.html',
  styleUrl: './screen-manager.component.scss'
})

export class ScreenManagerComponent {

  isLoggedIn: boolean = false;

  constructor(private router: Router, public dialog: MatDialog, private sessionService: SessionService) {
    this.isLoggedIn = !!this.sessionService.getToken();
  }

  navigateToMatches() {
    this.router.navigateByUrl('matches');
  }

  navigateToClubes() {
    this.router.navigateByUrl('clubes');
  }

  openLoginDialog(): void {
    const dialogRef = this.dialog.open(LoginDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.isLoggedIn = true;
      }
    });
  }

  openSignUpDialog(): void {
    this.dialog.open(RegisterDialogComponent, {
      width: '400px'
    });
  }

  navigateToProfile(): void {
    this.router.navigateByUrl('profile');
  }

  logout(): void {
    this.sessionService.logout();
    this.isLoggedIn = false;
  }
}
