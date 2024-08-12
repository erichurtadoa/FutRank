import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClubDetails } from '../../models/clubDetails';
import { ClubService } from '../../services/club.service';

@Component({
  selector: 'app-club-detail',
  templateUrl: './club-detail.component.html',
  styleUrl: './club-detail.component.scss'
})
export class ClubDetailComponent implements OnInit{

  public club: ClubDetails;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private clubService: ClubService,
  ) {}

  ngOnInit(): void {
    this.getClub();
  }

  public getClub() {
    this.clubService.getClubById(Number(this.route.snapshot.paramMap.get('id'))).subscribe((data: ClubDetails) => {
      this.club = data;
    })
  }

  public upVote(vote: boolean, clubId: number) {
    this.clubService.upVote(vote, clubId).subscribe(
      response => {
        this.getClub();
      },
      error => {}
    )
  }

  public addFavourite(clubId: number) {
    this.clubService.addFavourite(clubId).subscribe(
      response => {
        this.getClub();
      }
    )
  }
}
