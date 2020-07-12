import { Component, OnInit } from '@angular/core';
import { ProductService } from '../Services/product.service';
import { Product } from '../Models/product.model';
import { UpdateProductListService } from '../Services/update-product-list.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  public products: Product[];

  constructor(
    private productService: ProductService,
    private updateProductListService: UpdateProductListService) 
  { 
    this.updateProductListService.insertProductSubscriber$.subscribe(_ => this.ngOnInit());
  }

  ngOnInit(): void {
    this.getProducts();
  }

  private getProducts(): void {
    this.productService.getProducts().subscribe(products => this.products = products);
  }

  getProductCategoriesString(product: Product): string {
    return product.categories.map(c => c.name).join(", ");
  }
}
