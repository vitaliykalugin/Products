import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../Services/product.service';
import { Product } from '../Models/product.model';
import { CategoriesDropdownComponent } from '../categories-dropdown/categories-dropdown.component';
import { UpdateProductListService } from '../Services/update-product-list.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  @ViewChild(CategoriesDropdownComponent) categories: CategoriesDropdownComponent;

  product: Product = new Product();

  public errors: string[] = [];

  public isAddFailed: boolean;

  constructor(
    private productService: ProductService, 
    private updateProductListService: UpdateProductListService) { }

  ngOnInit(): void {
  }

  public addProduct() {
    this.product.categories = this.categories.selectedCategories;
    this.productService.insertProduct(this.product)
      .subscribe(
        response => {
          this.isAddFailed = false;
          this.product = new Product();
          this.updateProductListService.updateList();
        },
        response => {
          this.isAddFailed = true;
          let errorsDictionary = response.error.errors;

          for(let key in errorsDictionary){
            this.errors.push(errorsDictionary[key]);
          }
        }
      )
  }

}
