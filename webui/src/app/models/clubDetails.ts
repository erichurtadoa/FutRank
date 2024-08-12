export interface ClubDetails {
  id: number;
  name: string;
  code: string;
  founded: number;
  national: boolean;
  logo: string;
  popularity?: number;
  country: string;
  flag: string;
  venueName: string;
  venueAddress: string;
  venueCapacity: number;
  venueSurface: string;
  venueImage: string;
  venueCity: string;
  favourite?: boolean;
  upvote?: boolean;
  standings?: Standing[]
}

export interface Standing {
  competition: string;
  season: string;
  rank?: number;
}
