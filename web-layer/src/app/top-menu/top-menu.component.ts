import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { LocalService } from '../../services/local.service';
import { CommonModule } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-top-menu',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent implements OnInit {
  isAuthorized: boolean = false;
  currentRoute: string = '';
  userId: string = "";

  constructor(
    private localService: LocalService,
    private router: Router,
    private jwtHelperService: JwtHelperService
  ) { }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token){
      this.isAuthorized = true;
      var decodedData = this.jwtHelperService.decodeToken(token);
      this.userId = decodedData.nameid;
    }      
  }

  onExit() {
    this.isAuthorized = false;
    this.localService.remove(LocalService.AuthTokenName);
    window.location.href = '/login';
  }
}
