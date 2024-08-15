import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AnnouncementModel } from "../models/announcement.model";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class AnnouncementService {
    private path: string = "api/announcement/"

    constructor(private client: HttpClient) { }

    getById(id: string): Observable<AnnouncementModel> {
        return this.client.get<AnnouncementModel>(this.path + id);
    }

    getAll(): Observable<AnnouncementModel[]> {
        return this.client.get<AnnouncementModel[]>(this.path);
    }

    getSimiliar(id: string): Observable<AnnouncementModel[]> {
        return this.client.get<AnnouncementModel[]>(this.path + "similar/" + id);
    }

    getUserAnnouncements(id: string): Observable<AnnouncementModel[]> {
        return this.client.get<AnnouncementModel[]>(this.path + "user/" + id);
    }

    add(addAnnouncement: FormData): Observable<any> {
        return this.client.post(this.path, addAnnouncement);
    }

    update(UpdateAnnouncement: FormData): Observable<any> {
        return this.client.put(this.path, UpdateAnnouncement);
    }

    delete(id: string): Observable<any>{
        return this.client.delete(this.path + id);
    }
}