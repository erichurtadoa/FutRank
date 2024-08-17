import { Comments } from './comment';

export interface ForumThread {
  id: number;
  title: string;
  creator: string;
  createdAt: Date;
  commentsCount: number;
  comments: Comments[];
}
