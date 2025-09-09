import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'; // Importa Injectable per creare un servizio iniettabile
import { Observable } from 'rxjs'; // Importa Observable per gestire operazioni asincrone
import { Product, ProductDTO } from '../models/product.model'; // Importa i modelli Product e ProductDTO
/*
Questo file definisce un servizio Angular per gestire le operazioni CRUD sui prodotti.
*/
@Injectable({ providedIn: 'root' }) // Rende il servizio disponibile in tutta l'applicazione viene servito il pattern Singleton
export class ProductService {
  private apiUrl = 'http://localhost:5296/api/products'; // Modifica porta se diversa!

  constructor(private http: HttpClient) {} // Inietta HttpClient per effettuare richieste HTTP
  // metodi per le operazioni CRUD
  // tutti i metodi ritornano un Observable collegato ad un modello specifico che emette i dati quando disponibili
  getAll(): Observable<ProductDTO[]> {
    return this.http.get<ProductDTO[]>(this.apiUrl);
  }

  get(id: number): Observable<ProductDTO> {
    return this.http.get<ProductDTO>(`${this.apiUrl}/${id}`);
  }

  add(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product);
  }

  update(id: number, product: Product): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, product);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}