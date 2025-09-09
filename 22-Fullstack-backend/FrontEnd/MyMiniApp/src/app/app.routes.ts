import { Routes } from '@angular/router';
import { CategoriesList } from './pages/categories-list/categories-list';
import { CategoryForm } from './pages/category-form/category-form';
import { ProductsList } from './pages/products-list/product-list.component';
import { ProductForm } from './pages/product-form/product-form.component';
import { PurchasesList } from './pages/purchases-list/purchases-list';
import { PurchaseForm } from './pages/purchase-form/purchase-form';
import { UsersList } from './pages/users-list/users-list';
import { UserForm } from './pages/user-form/user-form';


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
