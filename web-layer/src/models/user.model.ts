import { AnnouncementModel } from "./announcement.model";

export class UserModel{
    id: string = "";
    userName: string = "";
    email: string = "";
    announcements: AnnouncementModel[] = [];
}