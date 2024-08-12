import { Component } from '@angular/core';
import { Fixture } from '../../models/fixture';
import { FixtureService } from '../../services/fixture.service';
import { MatDialog } from '@angular/material/dialog';
import { VoteDialogComponent } from '../../dialogs/vote-dialog/vote-dialog.component';
import { SessionService } from '../../services/session.service';
import { FixtureFilter } from '../../models/fixture-filter';
import { FixtureFilterDialogComponent } from '../../dialogs/fixture-filter-dialog/fixture-filter-dialog.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrl: './principal-page.component.scss'
})

export class PrincipalPageComponent {
  dataSource: Fixture[] = [];
  fixtureFilter: FixtureFilter;

  constructor(private fixtureService: FixtureService,
    public dialog: MatDialog,
    private sessionService: SessionService,
    private router: Router) { }

  ngOnInit(): void {
    if (this.fixtureFilter == null) {
      this.fixtureFilter = {
        team: '',
        league: '',
        season: ''
      }
    }
    this.getFixtures();
  }

  getFixtures(): void {
    this.fixtureService.fixtures$.subscribe(fixtures => {
      this.dataSource = fixtures;
    });

    this.sessionService.isLoggedIn.subscribe(loggedIn => {
      this.fixtureService.getFixtures(this.fixtureFilter);
    });

    //this.fixtureService.getFixtures();
  }

  openFilterDialog(): void {
    const dialogRef = this.dialog.open(FixtureFilterDialogComponent, {
      width: '450px',
      data: { filter: this.fixtureFilter }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.fixtureFilter = result;
        this.fixtureService.getFixtures(this.fixtureFilter);
      }
    });
  }

  public navigateToDetails(id: number) {
    console.log(id);
    this.router.navigate(['/matches', id]);
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
        this.fixtureService.getFixtures(this.fixtureFilter);
      },
      error => {
        console.error('Error submitting vote:', error);
      }
    );
  }
}
