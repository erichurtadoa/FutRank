import { Component } from '@angular/core';
import { Fixture } from '../../models/fixture';
import { FixtureService } from '../../services/fixture.service';
import { MatDialog } from '@angular/material/dialog';
import { VoteDialogComponent } from '../../dialogs/vote-dialog/vote-dialog.component';
import { SessionService } from '../../services/session.service';


@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrl: './principal-page.component.scss'
})

export class PrincipalPageComponent {
  dataSource: Fixture[] = [];

  constructor(private fixtureService: FixtureService,
    public dialog: MatDialog,
    private sessionService: SessionService) { }

  ngOnInit(): void {
    this.getFixtures();
  }

  getFixtures(): void {
    this.fixtureService.fixtures$.subscribe(fixtures => {
      this.dataSource = fixtures;
    });

    this.sessionService.isLoggedIn.subscribe(loggedIn => {
      this.fixtureService.getFixtures();
    });

    //this.fixtureService.getFixtures();
  }

  openVoteDialog(fixture: any): void {
    const dialogRef = this.dialog.open(VoteDialogComponent, {
      width: '450px',
      data: { match: fixture }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        this.submitVote(fixture.id, result);
      }
    });
  }

  submitVote(matchId: number, vote: number): void {
    this.fixtureService.voteFixture(matchId, vote).subscribe(
      response => {
        this.fixtureService.getFixtures();
      },
      error => {
        console.error('Error submitting vote:', error);
      }
    );
  }
}
