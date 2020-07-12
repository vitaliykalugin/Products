import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly productsUrl = 'api/Product';

  private headers = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.productsUrl}/list`);
  }

  insertProduct(product: Product): Observable<any> {
    return this.http.post(`${this.productsUrl}/insert`, JSON.stringify(product), this.headers);
  }
}
