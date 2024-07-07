import { Component } from '@angular/core';
import { Fixture } from '../../models/fixture';
import { FixtureService } from '../../services/fixture.service';
import { MatDialog } from '@angular/material/dialog';
import { VoteDialogComponent } from '../../dialogs/vote-dialog/vote-dialog.component';


@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrl: './principal-page.component.scss'
})

export class PrincipalPageComponent {
  dataSource: Fixture[] = [];

  constructor(private fixtureService: FixtureService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getFixtures();
  }

  getFixtures(): void {
    this.fixtureService.getFixtures()
      .subscribe(
        (data: Fixture[]) => {
        this.dataSource = data;
      },
      error => {
        console.log(error);
        console.error('Error al obtener los partidos:', error);
      });
  }

  openVoteDialog(fixture: any): void {
    const dialogRef = this.dialog.open(VoteDialogComponent, {
      width: '250px',
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
        console.log('Vote submitted successfully:', response);
        this.getFixtures(); // Actualiza la lista de partidos después de votar
      },
      error => {
        console.error('Error submitting vote:', error);
      }
    );
  }
}
