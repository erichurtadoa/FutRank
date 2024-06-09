import { Routes } from '@angular/router';
import { PrincipalPageComponent } from './dashboards/principal-page/principal-page.component';
import { ClubRankPageComponent } from './dashboards/club-rank-page/club-rank-page.component';
import { ClubDetailComponent } from './dashboards/club-detail/club-detail.component';


export const routes: Routes = [
  { path: '', redirectTo: 'matches', pathMatch: 'full' },
  { path: 'matches', component: PrincipalPageComponent },
  { path: 'clubes', component: ClubRankPageComponent },
  { path: 'clubes/:id', component: ClubDetailComponent },
];
