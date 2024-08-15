import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, RouterModule } from '@angular/router';

import { routes } from './app.routes';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { errorInterceptor } from '../inceptors/errorHandling.interceptor';
import { LocalService } from '../services/local.service';
import { jwtFactory } from './jwt-options';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes),
    provideClientHydration(),
    provideHttpClient(
      withInterceptors([errorInterceptor])
    ),
    importProvidersFrom([
      FormsModule,
      RouterModule,
      BrowserModule,
      JwtModule.forRoot({
        jwtOptionsProvider: {
          provide: JWT_OPTIONS,
          useFactory: jwtFactory,
          deps: [LocalService]
        }
      }),
    ])]
};
