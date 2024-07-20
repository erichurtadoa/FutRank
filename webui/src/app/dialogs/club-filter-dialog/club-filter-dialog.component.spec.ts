import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClubFilterDialogComponent } from './club-filter-dialog.component';

describe('ClubFilterDialogComponent', () => {
  let component: ClubFilterDialogComponent;
  let fixture: ComponentFixture<ClubFilterDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClubFilterDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClubFilterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
