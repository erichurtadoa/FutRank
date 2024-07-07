export interface Fixture {
  id: number;
  referee?: string;
  date: string;
  venueId: number;
  league: string;
  season?: string;
  round?: string;
  homeTeamId: number;
  logoHome: string;
  awayTeamId: number;
  logoAway: string;
  goalsHome?: number;
  goalsAway?: number;
  PenaltyHome?: number;
  PenaltyAway?: number;
  rate?: number;
  userNote?: number;
}
