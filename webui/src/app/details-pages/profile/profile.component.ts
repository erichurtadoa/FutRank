import { Component } from '@angular/core';
import { UserDetails } from '../../models/userDetails';
import { SessionService } from '../../services/session.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  public user: UserDetails;

  constructor(private sessionService: SessionService) {}

  ngOnInit(): void {
    this.sessionService.getUser().subscribe((data: UserDetails) => {
      this.user = data;
      console.log(this.user);
    })
  }
}
