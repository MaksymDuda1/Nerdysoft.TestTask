import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { AnnouncementModel } from '../../models/announcement.model';
import { UserModel } from '../../models/user.model';
import { AnnouncementService } from '../../services/announcement.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-announcements',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './user-announcements.component.html',
  styleUrl: './user-announcements.component.scss'
})
export class UserAnnouncementsComponent implements OnInit{

  announcements: AnnouncementModel[] = [];
  newAnnouncement = new AnnouncementModel();
  activeTab: string = 'announcements';
  message = "";
  user = new UserModel();

  constructor(
    private userService: UserService,
    private announcementService: AnnouncementService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      let id = params.get('id');
      if (id) {
        this.userService.getUserById(id).subscribe(
          data => this.user = data,
          errorResponse => this.message = errorResponse
        )

        this.announcementService.getAll().subscribe(
          data => this.announcements = data,
          errorResponse => this.message = errorResponse
        )
      }
    });
  }

  onFileChange(event: any) {
    if (event.target.files && event.target.files.length) {
      const file = event.target.files[0];
      this.newAnnouncement.photoPath = file;
    }
  }

  deleteAnnouncement(id: string) {
    this.announcementService.delete(id).subscribe(
      () => this.announcementService.getAll().subscribe(
        data => this.announcements = data,
        errorMessage => this.message = errorMessage
      )
    );
  }

  addPost() {
    let formData = new FormData();
    formData.append("Title", this.newAnnouncement.title);
    formData.append("Description", this.newAnnouncement.description);
    formData.append("UserId", this.user.id);
    if (this.newAnnouncement.photoPath)
      formData.append("Photo", this.newAnnouncement.photoPath);

    this.announcementService.add(formData).subscribe(
      () => this.announcementService.getAll().subscribe(
        data => {
          this.announcements = data;
          this.newAnnouncement = new AnnouncementModel();
          this.message = "Announcement added successfully!";
          setTimeout(() => {
            this.message = "";
          }, 3000);
        }),
      errorResponse => this.message = errorResponse)
  }

  setActiveTab(tab: string) {
    this.activeTab = tab;
  }
}
