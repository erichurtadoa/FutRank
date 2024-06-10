import { AppComponent } from './app.component';
import { ScreenManagerComponent } from './screen-manager/screen-manager.component';
import { PrincipalPageComponent } from './dashboards/principal-page/principal-page.component';
import { ClubRankPageComponent } from './dashboards/club-rank-page/club-rank-page.component';
import { ClubDetailComponent } from './dashboards/club-detail/club-detail.component';

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './helpers/auth.interceptor';
import { SessionService } from './services/session.service';
import { LoginDialogComponent } from './session/login-dialog/login-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { RegisterDialogComponent } from './session/register-dialog/register-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    ScreenManagerComponent,
    PrincipalPageComponent,
    ClubRankPageComponent,
    ClubDetailComponent,
    LoginDialogComponent,
    RegisterDialogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    MatToolbarModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule,
    MatListModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatInputModule,
    FormsModule,
    MatDialogModule
  ],
  providers: [
    SessionService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
