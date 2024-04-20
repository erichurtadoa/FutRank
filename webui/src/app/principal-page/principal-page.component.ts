import { Component } from '@angular/core';

const dummyData = [
  {
    equipoLocal: "Equipo A",
    equipoVisitante: "Equipo B",
    resultado: "2 - 1",
    fecha: "2024-03-30",
    competicion: "Liga",
    nota: 8,
    numeroVotos: 10
  },
  {
    equipoLocal: "Equipo C",
    equipoVisitante: "Equipo D",
    resultado: "0 - 0",
    fecha: "2024-03-31",
    competicion: "Copa",
    nota: 5,
    numeroVotos: 5
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
  {
    equipoLocal: "Equipo E",
    equipoVisitante: "Equipo F",
    resultado: "3 - 2",
    fecha: "2024-04-01",
    competicion: "Amistoso",
    nota: 9,
    numeroVotos: 8
  },
];

@Component({
  selector: 'app-principal-page',
  templateUrl: './principal-page.component.html',
  styleUrl: './principal-page.component.scss'
})

export class PrincipalPageComponent {
  dataSource = dummyData;
}
