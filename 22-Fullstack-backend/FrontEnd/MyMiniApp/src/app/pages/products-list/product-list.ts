import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductService } from '../../services/product';
import { ProductDTO } from '../../models/product.model';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <h2>Prodotti</h2>
    <button routerLink="/products/new">Aggiungi prodotto</button>
    <table>
      <tr>
        <th>Nome</th><th>Prezzo</th><th>Categoria</th><th>Azioni</th>
      </tr>
      <tr *ngFor="let p of products">
        <td>{{p.name}}</td>
        <td>{{p.price | currency:'EUR'}}</td>
        <td>{{p.categoryName}}</td>
        <td>
          <button [routerLink]="['/products', p.id]">Modifica</button>
          <button (click)="delete(p.id)">Elimina</button>
        </td>
      </tr>
    </table>
  `
})
export class ProductsList implements OnInit {
  products: ProductDTO[] = [];
  constructor(private service: ProductService) {}
  ngOnInit() { this.load(); }
  load() {
    this.service.getAll().subscribe( res => this.products = res);
  }
  delete(id: number) {
    if (confirm('Sicuro di eliminare?')) {
      this.service.delete(id).subscribe(() => this.load());
    }
  }
}