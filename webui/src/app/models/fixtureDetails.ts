import { CommentFixture } from "./commentFixture";

export interface FixtureDetails {
  id: number;
  referee?: string;
  date: string;
  venueName: string;
  venueImage: string;
  league: string;
  season?: string;
  round?: string;
  homeTeamName: string;
  logoHome: string;
  awayTeamName: string;
  logoAway: string;
  goalsHome?: number;
  goalsAway?: number;
  PenaltyHome?: number;
  PenaltyAway?: number;
  rate?: number;
  userNote?: number;
  comments: CommentFixture[];
}
