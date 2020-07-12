import { Component, OnInit } from '@angular/core';
import { Category } from '../Models/category.model';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-categories-dropdown',
  templateUrl: './categories-dropdown.component.html',
  styleUrls: ['./categories-dropdown.component.css']
})
export class CategoriesDropdownComponent implements OnInit {

  public categories: Category[];

  public categoriesNames: string[];

  public selectedCategories: Category[] = new Array<Category>();

  constructor(private categoryService: CategoryService ) { }

  ngOnInit(): void {
    this.getCategories();
  }

  public addSelectedCategory(name: string): void {
    let category: Category = this.categories.find(c => c.name === name);
    this.selectedCategories.push(category);
  }

  public removeCategory(categoryObject: any): void {
    this.selectedCategories = this.selectedCategories.filter(c => c.name != categoryObject.value);
  }

  public clearSelectedCategories(event: any): void {
    this.selectedCategories = [];
  }

  private getCategories(): void {
    this.categoryService.getCategories().subscribe(categories =>{
      this.categories = categories;
      this.categoriesNames = this.getCategoriesNames();
    });
  }

  private getCategoriesNames(): string[] {
    return this.categories.map(c => c.name);
  }

}
