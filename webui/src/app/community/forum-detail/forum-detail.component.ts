import { Component } from '@angular/core';
import { ForumThread } from '../../models/forum-thread';
import { ForumService } from '../../services/community.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-forum-detail',
  templateUrl: './forum-detail.component.html',
  styleUrl: './forum-detail.component.scss'
})
export class ForumDetailComponent {
  thread: ForumThread | null = null;
  content: string;

  constructor(private route: ActivatedRoute,
    private forumService: ForumService) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.forumService.getThread(id).subscribe(thread => {
      this.thread = thread;
    });
  }

  addComment(): void {
    if (this.thread) {
      this.forumService.createcomments(this.thread.id, this.content).subscribe(comments => {
        this.thread!.comments.push(comments);
        this.content = '';
      });
    }
  }
}
