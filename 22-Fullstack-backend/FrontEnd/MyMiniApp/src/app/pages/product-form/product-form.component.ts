import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { CategoryService } from '../services/category';
import { ProductService } from '../services/product';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  template: `
    <h2>{{isNew ? 'Aggiungi' : 'Modifica'}} prodotto</h2>
    <form (ngSubmit)="save()" *ngIf="categories.length">
      <label>Nome: <input [(ngModel)]="model.name" name="name" required></label><br>
      <label>Prezzo: <input [(ngModel)]="model.price" name="price" type="number" required></label><br>
      <label>Categoria:
        <select [(ngModel)]="model.categoryId" name="categoryId" required>
          <option *ngFor="let cat of categories" [value]="cat.id">{{cat.name}}</option>
        </select>
      </label><br>
      <button type="submit">Salva</button>
      <button type="button" (click)="goBack()">Annulla</button>
    </form>
  `
})
export class ProductForm implements OnInit {
  model: Product = { id: 0, name: '', price: 0, categoryId: 0 };
  categories: Category[] = [];
  isNew = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: ProductService,
    private catService: CategoryService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.catService.getAll().subscribe(cats => {
      this.categories = cats;
      if (id) {
        this.isNew = false;
        this.service.get(+id).subscribe(prod => {
          this.model = {
            id: prod.id,
            name: prod.name,
            price: prod.price,
            categoryId: this.categories.find(c => c.name === prod.categoryName)?.id || 0
          };
        });
      }
    });
  }

  save() {
    if (this.isNew) {
      this.service.add(this.model).subscribe(() => this.goBack());
    } else {
      this.service.update(this.model.id, this.model).subscribe(() => this.goBack());
    }
  }

  goBack() {
    this.router.navigate(['/products']);
  }
}
