import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-screen-manager',
  standalone: true,
  imports: [CommonModule, MatToolbarModule, MatFormFieldModule, MatButtonModule, MatIconModule, MatMenuModule],
  templateUrl: './screen-manager.component.html',
  styleUrl: './screen-manager.component.scss'
})
export class ScreenManagerComponent {

}
