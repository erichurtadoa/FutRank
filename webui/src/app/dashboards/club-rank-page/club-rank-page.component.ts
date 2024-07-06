import { Component, OnInit } from '@angular/core';
import { Club } from '../../models/club';
import { ClubService } from '../../services/club.service';
import { Router } from '@angular/router';
import { SessionService } from '../../services/session.service';

@Component({
  selector: 'app-club-rank-page',
  templateUrl: './club-rank-page.component.html',
  styleUrl: './club-rank-page.component.scss'
})

export class ClubRankPageComponent implements OnInit {
  dataSource: Club[] = [];

  constructor(
    private clubService: ClubService,
    private router: Router,
    private sessionService: SessionService
  ) { }

  ngOnInit(): void {
    this.getClubs();
  }

  getClubs(): void {
    this.clubService.clubs$.subscribe(clubs => {
      this.dataSource = clubs;
    });

    this.sessionService.isLoggedIn.subscribe(loggedIn => {
        this.clubService.getClubs();
    });

    this.clubService.getClubs();
  }

  public navigateToDetails(id: number) {
    console.log(id);
    this.router.navigate(['/clubes', id]);
  }

  public upVote(vote: boolean, clubId: number) {
    this.clubService.upVote(vote, clubId).subscribe(
      response => {
        this.clubService.getClubs();
      }
    )
  }

  public addFavourite(clubId: number) {
    this.clubService.addFavourite(clubId).subscribe(
      response => {
        this.clubService.getClubs();
      }
    )
  }
}
