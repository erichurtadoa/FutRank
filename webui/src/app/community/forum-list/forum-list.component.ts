import { Component } from '@angular/core';
import { ForumService } from '../../services/community.service';
import { ForumThread } from '../../models/forum-thread';
import { CreateThreadComponent } from '../../dialogs/create-thread/create-thread.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrl: './forum-list.component.scss'
})
export class ForumListComponent {
  threads: ForumThread[] = [];

  constructor(private forumService: ForumService,
    private dialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.loadThreads();
  }

  loadThreads(): void {
    this.forumService.getThreads().subscribe(threads => {
      this.threads = threads;
    });
  }

  navigateToThread(id: number) {
    this.router.navigate(['/forum', id]);
  }

  openCreateThreadDialog(): void {
    const dialogRef = this.dialog.open(CreateThreadComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        this.loadThreads();
      }
    });
  }
}
