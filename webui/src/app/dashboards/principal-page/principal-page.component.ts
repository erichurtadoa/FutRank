import { Component } from '@angular/core';
import { Fixture } from '../../models/fixture';
import { FixtureService } from '../../services/fixture.service';

@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrl: './principal-page.component.scss'
})

export class PrincipalPageComponent {
  dataSource: Fixture[] = [];

  constructor(private fixtureService: FixtureService) { }

  ngOnInit(): void {
    this.getClubs();
  }

  getClubs(): void {
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
}
