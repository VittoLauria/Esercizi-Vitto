import { Routes } from '@angular/router';
import { AcquistiListComponent } from './pages/acquisti-list/acquisti-list.component';

export const routes: Routes = [
    { path: 'acquisti', component: AcquistiListComponent },
    { path: '**', redirectTo: 'acquisti' }
];
