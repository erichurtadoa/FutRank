import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FixtureService } from '../../services/fixture.service';
import { MatDialog } from '@angular/material/dialog';
import { VoteDialogComponent } from '../../dialogs/vote-dialog/vote-dialog.component';
import { FixtureDetails } from '../../models/fixtureDetails';
import { CommentFixture } from '../../models/commentFixture';

@Component({
  selector: 'app-fixture-detail',
  templateUrl: './fixture-detail.component.html',
  styleUrl: './fixture-detail.component.scss'
})
export class FixtureDetailComponent {
  public fixture: FixtureDetails;
  content: string;
  commentsFixture: CommentFixture[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fixtureService: FixtureService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getFixture();
  }

  public getFixture(): void {
    this.fixtureService.getFixtureById(Number(this.route.snapshot.paramMap.get('id'))).subscribe((data: FixtureDetails) => {
      this.fixture = data;
      console.log(this.fixture);
      console.log(this.fixture.comments.values);
    })
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
        this.getFixture();
      },
      error => {
        console.error('Error submitting vote:', error);
      }
    );
  }

  addComment(): void {
    if (this.fixture) {
      this.fixtureService.createcomments(this.fixture.id, this.content).subscribe(comments => {
        console.log(comments);
        if (!this.fixture!.comments) {
          this.fixture!.comments = [];
        }
        this.fixture!.comments.push(comments);
        this.content = '';
      });
    }
  }
}
