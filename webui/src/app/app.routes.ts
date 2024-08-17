import { Routes } from '@angular/router';
import { PrincipalPageComponent } from './dashboards/principal-page/principal-page.component';
import { ClubRankPageComponent } from './dashboards/club-rank-page/club-rank-page.component';
import { ClubDetailComponent } from './details-pages/club-detail/club-detail.component';
import { ProfileComponent } from './details-pages/profile/profile.component';
import { FixtureDetailComponent } from './details-pages/fixture-detail/fixture-detail.component';
import { ForumListComponent } from './community/forum-list/forum-list.component';
import { ForumDetailComponent } from './community/forum-detail/forum-detail.component';


export const routes: Routes = [
  { path: '', redirectTo: 'matches', pathMatch: 'full' },
  { path: 'matches', component: PrincipalPageComponent },
  { path: 'matches/:id', component: FixtureDetailComponent },
  { path: 'clubes', component: ClubRankPageComponent },
  { path: 'clubes/:id', component: ClubDetailComponent },
  { path: 'profile/:username', component: ProfileComponent },
  { path: 'forum', component: ForumListComponent },
  { path: 'forum/:id', component: ForumDetailComponent },
];
