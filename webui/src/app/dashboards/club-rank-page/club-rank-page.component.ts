import { Component, OnInit } from '@angular/core';
import { Club } from '../../models/club';
import { ClubService } from '../../services/club.service';
import { Router } from '@angular/router';
import { SessionService } from '../../services/session.service';
import { ClubFilterDialogComponent } from '../../dialogs/club-filter-dialog/club-filter-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ClubFilter } from '../../models/club-filter copy';

@Component({
  selector: 'app-club-rank-page',
  templateUrl: './club-rank-page.component.html',
  styleUrl: './club-rank-page.component.scss'
})

export class ClubRankPageComponent implements OnInit {
  dataSource: Club[] = [];
  clubFilter: ClubFilter;

  constructor(
    private clubService: ClubService,
    private router: Router,
    private sessionService: SessionService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    if (this.clubFilter == null) {
      this.clubFilter = {
        team: '',
        country: ''
      }
    }
    this.getClubs();
  }

  getClubs(): void {
    this.clubService.clubs$.subscribe(clubs => {
      this.dataSource = clubs;
    });

    this.sessionService.isLoggedIn.subscribe(loggedIn => {
        this.clubService.getClubs(this.clubFilter);
    });

    //this.clubService.getClubs(this.clubFilter);
  }

  openFilterDialog(): void {
    const dialogRef = this.dialog.open(ClubFilterDialogComponent, {
      width: '450px',
      data: { filter: this.clubFilter }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.clubFilter = result;
        this.clubService.getClubs(this.clubFilter);
      }
    });
  }

  public navigateToDetails(id: number) {
    console.log(id);
    this.router.navigate(['/clubes', id]);
  }

  public upVote(vote: boolean, clubId: number) {
    this.clubService.upVote(vote, clubId).subscribe(
      response => {
        this.clubService.getClubs(this.clubFilter);
      },
      error => {}
    )
  }

  public addFavourite(clubId: number) {
    this.clubService.addFavourite(clubId).subscribe(
      response => {
        this.clubService.getClubs(this.clubFilter);
      }
    )
  }
}
