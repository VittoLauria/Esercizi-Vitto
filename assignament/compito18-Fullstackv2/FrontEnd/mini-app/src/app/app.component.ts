import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [RouterOutlet, RouterLink, RouterLinkActive],
    template: `
    <nav class="p-4 bg-gray-100 mb-6 flex space-x-4">
    <a routerLink="/acquisti" routerLinkActive="font-bold">Acquisti</a>
    </nav>
    <main class="p-4">
    <router-outlet></router-outlet>
    </main>
    `,
    styles: [`
    nav a { text-decoration: none; color: #333; }
    nav a.font-bold { font-weight: bold; }
    main { background: #fafafa; min-height: calc(100vh - 64px); }
    `]
})
export class AppComponent {}