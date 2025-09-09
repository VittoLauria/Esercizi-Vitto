
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { User } from '../models/user.model';
import { UserService } from '../services/user';


@Component({
  selector: 'app-users-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <h2>Utenti</h2>
    <button routerLink="/users/new">Aggiungi utente</button>
    <table>
      <tr>
        <th>Nome</th><th>Indirizzo</th><th>Azioni</th>
      </tr>
      <tr *ngFor="let u of users">
        <td>{{u.name}}</td>
        <td>{{u.address}}</td>
        <td>
          <button [routerLink]="['/users', u.id]">Modifica</button>
          <button (click)="delete(u.id)">Elimina</button>
        </td>
      </tr>
    </table>
    ``
  
})
export class UsersList implements OnInit {
  users: User[] = [];
  constructor(private service: UserService) {}
  ngOnInit() { this.load(); }
  load() {
    this.service.getAll().subscribe(res => this.users = res);
  }
  delete(id: number) {
    if (confirm('Sicuro di eliminare?')) {
      this.service.delete(id).subscribe(() => this.load());
    }
  }
}
