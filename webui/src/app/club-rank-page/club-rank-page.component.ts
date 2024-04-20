import { Component } from '@angular/core';

const dummyData = [
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
  {
    club: "Equipo A",
    country: "Country",
    popularity: "2",
  },
];

@Component({
  selector: 'app-club-rank-page',
  templateUrl: './club-rank-page.component.html',
  styleUrl: './club-rank-page.component.scss'
})

export class ClubRankPageComponent {
  dataSource = dummyData;
}
