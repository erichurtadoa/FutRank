import { Component } from '@angular/core';
import { UserRegister } from '../../models/userRegister';
import { MatDialogRef } from '@angular/material/dialog';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { SessionService } from '../../services/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrl: './register-dialog.component.scss'
})
export class RegisterDialogComponent {
  userRegister: UserRegister = {
    username: '',
    email: '',
    password: '',
    confirmPassword: ''
  }

  constructor(
    public dialogRef: MatDialogRef<RegisterDialogComponent>,
    private sessionService: SessionService,
    private router: Router
  ) {}

  onCancel(): void {
    this.dialogRef.close();
  }

  onSignUp(): void {
    this.sessionService.register(this.userRegister).subscribe(
      () => {
        this.dialogRef.close(true);
      },
      error => {
        console.error('Login failed', error);
      }
    );
  }
}
