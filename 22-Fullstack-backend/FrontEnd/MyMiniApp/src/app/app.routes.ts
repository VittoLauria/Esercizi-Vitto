import { Routes } from '@angular/router';
import {CategoriesList} from './categories-list/categories-list';
import { CategoryForm } from './category-form/category-form';
import { ProductsList } from './products-list/products-list';
import { ProductForm } from './product-form/product-form';
import { PurchasesList } from './purchases-list/purchases-list';
import { PurchaseForm } from './purchase-form/purchase-form';
import { UsersList } from './users-list/users-list';
import { UserForm } from './user-form/user-form';


export const routes: Routes = [
    { path: '', redirectTo: 'products', pathMatch: 'full'},

    {path: 'products', component: ProductsList },
    {path: 'products/new', component: ProductForm },
    {path: 'products/:id', component: ProductForm },

    {path: 'users', component: UsersList },
    {path: 'users/new', component: UserForm },
    {path: 'users/:id', component: UserForm },

    {path: 'categories', component: CategoriesList },
    {path: 'categories/new', component: CategoryForm },
    {path: 'categories/:id', component: CategoryForm },
    
    {path: 'purchases', component: PurchasesList },
    {path: 'purchases/new', component: PurchaseForm },
    {path: 'purchases/:id', component: PurchaseForm },
];
