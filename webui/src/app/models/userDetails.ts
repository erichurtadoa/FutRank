import { Club } from "./club";
import { Fixture } from "./fixture";

export interface UserDetails {
  username: string;
  email: string;
  name: string;
  dateSignUp: string;
  fixtureTime: number;
  favouriteClub?: Club;
}
