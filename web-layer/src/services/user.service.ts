import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserModel } from "../models/user.model";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class UserService {
    constructor(private client: HttpClient) { }
    
    getAll(): Observable<UserModel[]> {
        return this.client.get<UserModel[]>('api/user');
    }

    getUserById(id: string): Observable<UserModel> {
        return this.client.get<UserModel>('api/user/' + id);
    }

}