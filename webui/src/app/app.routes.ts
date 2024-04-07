import { Routes } from '@angular/router';
import { PrincipalPageComponent } from './principal-page/principal-page.component';


export const routes: Routes = [
  { path: '', redirectTo: 'matches', pathMatch: 'full' },
  { path: 'matches', component: PrincipalPageComponent },
];
