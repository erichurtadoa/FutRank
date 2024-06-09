import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClubRankPageComponent } from './club-rank-page.component';

describe('ClubRankPageComponent', () => {
  let component: ClubRankPageComponent;
  let fixture: ComponentFixture<ClubRankPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClubRankPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClubRankPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
