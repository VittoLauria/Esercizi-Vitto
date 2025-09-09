import { provideHttpClient } from '@angular/common/http';
// comando installazione material: ng add @angular/material
import { MatNativeDateModule } from '@angular/material/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';


bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    MatNativeDateModule
  ]
 });
