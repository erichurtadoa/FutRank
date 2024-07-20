import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FixtureFilterDialogComponent } from './fixture-filter-dialog.component';

describe('FixtureFilterDialogComponent', () => {
  let component: FixtureFilterDialogComponent;
  let fixture: ComponentFixture<FixtureFilterDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FixtureFilterDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FixtureFilterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
