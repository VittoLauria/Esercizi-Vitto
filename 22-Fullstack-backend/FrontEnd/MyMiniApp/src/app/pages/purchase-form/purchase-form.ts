import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Product } from '../../models/product.model';
import { Purchase } from '../../models/purchase.model';
import { User } from '../../models/user.model';
import { ProductService } from '../../services/product';
import { PurchaseService } from '../../services/purchase';
import { UserService } from '../../services/user';

@Component({
  selector: 'app-purchase-form',
    standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  template: `
    <h2>{{isNew ? 'Aggiungi' : 'Modifica'}} acquisto</h2>
    <form (ngSubmit)="save()" *ngIf="users.length && products.length">
      <label>Utente:
        <select [(ngModel)]="model.userId" name="userId" required>
          <option *ngFor="let u of users" [value]="u.id">{{u.name}}</option>
        </select>
      </label><br>
      <label>Prodotto:
        <select [(ngModel)]="model.productId" name="productId" required>
          <option *ngFor="let p of products" [value]="p.id">{{p.name}}</option>
        </select>
      </label><br>
      <label>Quantità: <input [(ngModel)]="model.quantity" name="quantity" type="number" required></label><br>
      <label>Data: <input [(ngModel)]="model.purchaseDate" name="purchaseDate" type="date" required></label><br>
      <button type="submit">Salva</button>
      <button type="button" (click)="goBack()">Annulla</button>
    </form>
  `
}) 
export class PurchaseForm implements OnInit {
  model: Purchase = { id: 0, userId: 0, productId: 0, quantity: 1, purchaseDate: '' };
  users: User[] = [];
  products: Product[] = [];
  isNew = true;

 constructor(
  private route: ActivatedRoute,
  private router: Router,
  private service: PurchaseService,
  private userService: UserService,
  private productService: ProductService
 ) {}

 ngOnInit() {
  this.userService.getAll().subscribe(u => this.users = u);
  this.productService.getAll().subscribe(p => this.products = p.map(pr => ({
    id: pr.id, name: pr.name, price: pr.price, categoryId: 0
  })));

  
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isNew = false;
      this.service.get(+id).subscribe(a => this.model = a);
    }
 }
 save() {
  if(this.isNew) {
    this.service.add(this.model).subscribe(() => this.goBack());
  }else {
    this.service.update(this.model.id, this.model).subscribe(() => this.goBack());
  }
 }

 goBack() {
  this.router.navigate(['/purchases']);
 }
}

