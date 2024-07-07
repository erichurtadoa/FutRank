import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-vote-dialog',
  templateUrl: './vote-dialog.component.html',
  styleUrl: './vote-dialog.component.scss'
})

export class VoteDialogComponent {
  vote: number = this.data.match.userNote ? this.data.match.userNote: 0;

  constructor(
    public dialogRef: MatDialogRef<VoteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  onVoteClick(): void {
    this.dialogRef.close(this.vote);
  }

  onClearClick(): void {
    this.dialogRef.close(-1);
  }
}
