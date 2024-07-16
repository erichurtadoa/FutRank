import { Component } from '@angular/core';
import { UserDetails } from '../../models/userDetails';
import { SessionService } from '../../services/session.service';
import { FixtureService } from '../../services/fixture.service';
import { ClubService } from '../../services/club.service';
import { Fixture } from '../../models/fixture';
import { Club } from '../../models/club';

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
    private clubService: ClubService
  ) {}

  ngOnInit(): void {
    this.sessionService.getUser().subscribe((data: UserDetails) => {
      this.user = data;
      this.date = new Date(this.user.dateSignUp);
      console.log(this.date);
    })
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
