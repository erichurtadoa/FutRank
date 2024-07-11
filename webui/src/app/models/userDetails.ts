import { Club } from "./club";
import { Guid } from 'guid-typescript';

export interface UserDetails {
  id: Guid;
  username: string;
  email: string;
  name?: string;
  dateSignUp: string;
  fixtureTime: number;
  favouriteClub?: Club;
}
