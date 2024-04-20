import { Routes } from '@angular/router';
import { PrincipalPageComponent } from './principal-page/principal-page.component';
import { ClubRankPageComponent } from './club-rank-page/club-rank-page.component';


export const routes: Routes = [
  { path: '', redirectTo: 'matches', pathMatch: 'full' },
  { path: 'matches', component: PrincipalPageComponent },
  { path: 'clubes', component: ClubRankPageComponent },
];
