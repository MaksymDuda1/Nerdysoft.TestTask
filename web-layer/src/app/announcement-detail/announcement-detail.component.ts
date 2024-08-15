import { Component, OnInit } from '@angular/core';
import { AnnouncementService } from '../../services/announcement.service';
import { AnnouncementModel } from '../../models/announcement.model';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-announcement-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './announcement-detail.component.html',
  styleUrl: './announcement-detail.component.scss'
})
export class AnnouncementDetailComponent implements OnInit {
  errorMessage = "";
  announcement: AnnouncementModel = new AnnouncementModel();
  similarAnnouncements: AnnouncementModel[] = [];
  id: string | null = null;

  constructor(
    private announcementService: AnnouncementService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.id = params.get('id');
      if (this.id) {
        this.loadAnnouncement(this.id);
        this.loadSimilarAnnouncements(this.id);
      }
    });
  }

  loadAnnouncement(id: string): void {
    this.announcementService.getById(id).subscribe({
      next: (data) => this.announcement = data,
      error: (error) => this.errorMessage = error
    });
  }

  loadSimilarAnnouncements(id: string): void {
    this.announcementService.getSimiliar(id).subscribe(
      data => this.similarAnnouncements = data,
      error => this.errorMessage = error)
  };
}