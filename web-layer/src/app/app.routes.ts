import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { authGuard } from '../guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { AnnouncementDetailComponent } from './announcement-detail/announcement-detail.component';
import { UpdateAnnouncementComponent } from './update-announcement/update-announcement.component';
import { UserAnnouncementsComponent } from './user-announcements/user-announcements.component';

export const routes: Routes = [

    { path: "login", component: LoginComponent },
    { path: "registration", component: RegistrationComponent },
    { path: "home", component: HomeComponent, canActivate: [authGuard] },
    { path: "announcement-detail/:id", component: AnnouncementDetailComponent, canActivate: [authGuard] },
    { path: "user-announcements/:id", component: UserAnnouncementsComponent, canActivate: [authGuard] },
    { path: "update-announcement/:id", component: UpdateAnnouncementComponent, canActivate: [authGuard] },
    { path: "**", redirectTo: "/login" },
];
