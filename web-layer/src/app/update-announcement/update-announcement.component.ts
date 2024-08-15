import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { AnnouncementModel } from '../../models/announcement.model';
import { FormsModule } from '@angular/forms';
import { AnnouncementService } from '../../services/announcement.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-update-announcement',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './update-announcement.component.html',
  styleUrl: './update-announcement.component.scss'
})
export class UpdateAnnouncementComponent implements OnInit {
  updateAnnouncement: AnnouncementModel = new AnnouncementModel();
  message = "";

  constructor(
    private route: ActivatedRoute,
    private announcementService: AnnouncementService,
    private location: Location) { }


  onFileChange(event: any) {
    if (event.target.files && event.target.files.length) {
      const file = event.target.files[0];
      this.updateAnnouncement.photoPath = file;
    }
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      let id = params.get('id');
      if (id) {
        this.announcementService.getById(id).subscribe(
          data => {
            this.updateAnnouncement = data;
          }, errorResponse => {
            this.message = errorResponse
          })
      }
    });
  }

  goBack() {
    this.location.back();
  }

  onUpdate() {
    let formData = new FormData();
    formData.append("Id", this.updateAnnouncement.id);
    formData.append("Title", this.updateAnnouncement.title);
    formData.append("Description", this.updateAnnouncement.description);

    if (this.updateAnnouncement.photoPath)
      formData.append("Photo", this.updateAnnouncement.photoPath);

    this.announcementService.update(formData).subscribe(
      () => {
        this.message = "Announcement updated successfully!";
        setTimeout(() => {
          this.message = "";
        }, 3000);
      },
      errorResponse => this.message = errorResponse)
  }
}
