import { Component } from '@angular/core';
import { ForumService } from '../../services/community.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-thread',
  templateUrl: './create-thread.component.html',
  styleUrl: './create-thread.component.scss'
})
export class CreateThreadComponent {
  title: string = '';

  constructor(
    private forumService: ForumService,
    public dialogRef: MatDialogRef<CreateThreadComponent>
  ) {}

  createThread(): void {
    console.log (this.title);
    this.forumService.createThread(this.title).subscribe(() => {
      this.dialogRef.close(true);
    });
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
