import { Component, OnInit } from '@angular/core';
import { Club } from '../../models/club';
import { ClubService } from '../../services/club.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-club-rank-page',
  templateUrl: './club-rank-page.component.html',
  styleUrl: './club-rank-page.component.scss'
})

export class ClubRankPageComponent implements OnInit {
  dataSource: Club[] = [];

  constructor(
    private clubService: ClubService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getClubs();
  }

  getClubs(): void {
    this.clubService.getClubs()
      .subscribe(
        (data: Club[]) => {
        this.dataSource = data;
      },
      error => {
        console.log(error);
        console.error('Error al obtener los clubs:', error);
      });
  }

  public navigateToDetails(id: number) {
    console.log(id);
    this.router.navigate(['/clubes', id]);
  }
}
