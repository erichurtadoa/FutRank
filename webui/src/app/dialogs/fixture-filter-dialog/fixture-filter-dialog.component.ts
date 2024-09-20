import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-fixture-filter-dialog',
  templateUrl: './fixture-filter-dialog.component.html',
  styleUrl: './fixture-filter-dialog.component.scss'
})
export class FixtureFilterDialogComponent {
  filterForm: FormGroup;
  leagues: string[] = ['', 'La Liga', 'Premier League', 'Serie A'];
  seasons:string[] = ['', '2023', '2022', '2021'];

  constructor(public dialogRef: MatDialogRef<FixtureFilterDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {
    this.filterForm = this.fb.group({
      team: [data.filter?.team || ''],
      league: [data.filter?.league || ''],
      season: [data.filter?.season || '']
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
