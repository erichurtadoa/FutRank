export interface Club {
  id: number;
  name: string;
  code: string;
  founded: number;
  national: boolean;
  logo: string;
  popularity?: number;
  country: string;
  flag: string;
  venue: number;
  city: string;
  favourite?: boolean;
  upvote?: boolean;
}
