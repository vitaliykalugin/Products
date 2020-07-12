import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../Models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private readonly categoriesUrl = 'api/Category';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(`${this.categoriesUrl}/list`);
  }
}
