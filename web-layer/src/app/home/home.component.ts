import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Router } from 'express';
import { AnnouncementService } from '../../services/announcement.service';
import { AnnouncementModel } from '../../models/announcement.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  constructor(private announcementService: AnnouncementService){}

  announcements : AnnouncementModel[] = [];
  errorMessage = "";

  ngOnInit(): void {
    this.announcementService.getAll().subscribe(
      data => this.announcements = data,
      errorResponse => this.errorMessage = errorResponse)
  }

}
