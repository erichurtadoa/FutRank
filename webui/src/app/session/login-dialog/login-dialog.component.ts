import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SessionService } from '../../services/session.service';
import { UserSession } from '../../models/userSession';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.scss']
})
export class LoginDialogComponent {
  userSession: UserSession = {
    username: '',
    password: ''
  }

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private sessionService: SessionService,
    private router: Router
  ) {}

  onCancel(): void {
    this.dialogRef.close();
  }

  onLogin(): void {
    this.sessionService.login(this.userSession).subscribe(
      () => {
        this.dialogRef.close(true);
      },
      error => {
        console.error('Login failed', error);
      }
    );
  }
}
