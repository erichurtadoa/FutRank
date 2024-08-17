import { Component } from '@angular/core';
import { UserDetails } from '../../models/userDetails';
import { SessionService } from '../../services/session.service';
import { FixtureService } from '../../services/fixture.service';
import { ClubService } from '../../services/club.service';
import { Fixture } from '../../models/fixture';
import { Club } from '../../models/club';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  user: UserDetails;
  date: Date;
  showTables: boolean = false;
  userFixtures: Fixture[];
  userClubs: Club[];


  constructor(private sessionService: SessionService,
    private fixtureService: FixtureService,
    private clubService: ClubService,
    private route: ActivatedRoute
  ) {
    route.params.subscribe(val => {
      this.sessionService.getUserByUsername(String(this.route.snapshot.paramMap.get('username'))).subscribe((data: UserDetails) => {
        this.user = data;
        this.date = this.parseDate(this.user.dateSignUp);
      })
    });
  }

  parseDate(dateString: string): Date {
    const [day, month, yearAndTime] = dateString.split('/');
    const [year, time] = yearAndTime.split(' ');
    const [hour, minute, second] = time.split(':');

    return new Date(+year, +month - 1, +day, +hour, +minute, +second);
  }

  toggleTables() {
    if (!this.showTables) {
      this.fixtureService.getUserFixtures(this.user.id).subscribe((fixtureData: Fixture[]) => {
        this.userFixtures = fixtureData;
        this.showTables = true;
      })
      this.clubService.getUserClubs(this.user.id).subscribe((clubData: Club[]) => {
        this.userClubs = clubData;
        this.showTables = true;
      })
    }
    else
    this.showTables = false;
  }
}
