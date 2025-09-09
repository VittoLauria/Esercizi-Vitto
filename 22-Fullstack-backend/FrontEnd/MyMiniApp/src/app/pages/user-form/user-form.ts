import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  template: `
    <h2>{{isNew ? 'Aggiungi' : 'Modifica'}} utente</h2>
    <form (ngSubmit)="save()">
      <label>Nome: <input [(ngModel)]="model.name" name="name" required></label><br>
      <label>Città: <input [(ngModel)]="model.address.citta" name="addressCitta" required></label><br>
      <label>Via: <input [(ngModel)]="model.address.via" name="addressVia" required></label><br>
      <label>CAP: <input [(ngModel)]="model.address.cap" name="addressCap" required></label><br>
      <button type="submit">Salva</button>
      <button type="button" (click)="goBack()">Annulla</button>
    </form>
  `
})
export class UserForm implements OnInit {
  model: User = {
  id: 0,
  name: '',
  address: { citta: '', via: '', cap: '' }
  };
  isNew = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: UserService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isNew = false;
      this.service.get(+id).subscribe(u => this.model = u);
    }
  }

  save() {
    if (this.isNew) {
      this.service.add(this.model).subscribe(() => this.goBack());
    } else {
      this.service.update(this.model.id, this.model).subscribe(() => this.goBack());
    }
  }

  goBack() {
    this.router.navigate(['/users']);
  }
}