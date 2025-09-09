import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PurchaseDTO } from '../../models/purchase.model';
import { PurchaseService } from '../../services/purchase';

@Component({
  selector: 'app-purchases-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <h2>Acquisti</h2>
    <button routerLink="/purchases/new">Aggiungi acquisto</button>
    <table>
      <tr>
        <th>Utente</th><th>Prodotto</th><th>Categoria</th><th>Quantità</th><th>Data</th><th>Azioni</th>
      </tr>
      <tr *ngFor="let p of purchases">
        <td>{{p.userName}}</td>
        <td>{{p.productName}}</td>
        <td>{{p.productCategory}}</td> 
        <td>{{p.quantity}}</td>
        <td>{{p.purchaseDate | date:'shortDate'}}</td>
        <td>
          <button [routerLink]="['/purchases', p.id]">Modifica</button>
          <button (click)="delete(p.id)">Elimina</button>
        </td>
      </tr>
    </table>
  `
})
export class PurchasesList implements OnInit {
  purchases: PurchaseDTO[] = [];
  constructor(private service: PurchaseService) {}
  ngOnInit() { this.load(); }
  load() {
    this.service.getAll().subscribe(res => this.purchases = res);
  }
  delete(id: number) {
    if (confirm('Sicuro di eliminare?')) {
      this.service.delete(id).subscribe(() => this.load());
    }
  }
}