import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-club-filter-dialog',
  templateUrl: './club-filter-dialog.component.html',
  styleUrl: './club-filter-dialog.component.scss'
})
export class ClubFilterDialogComponent {
  filterForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<ClubFilterDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {
    this.filterForm = this.fb.group({
      team: [data.filter?.team || ''],
      country: [data.filter?.country || '']
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
