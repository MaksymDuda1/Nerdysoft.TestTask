import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from '../../models/login.model';
import { AuthService } from '../../services/auth.service';
import { LocalService } from '../../services/local.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  constructor(
    private authService: AuthService,
    private localService: LocalService,
  ) { }

  loginModel = new LoginModel();
  errorMessage = "";

  onLogin() {
    this.authService.login(this.loginModel).subscribe((data: any) => {
      this.localService.put(LocalService.AuthTokenName, data.accessToken);
      console.log(data.accessToken);
      window.location.href = '/home';
    },
      (errorResponse: any) => {
        this.errorMessage = errorResponse;
      })
  }
}
