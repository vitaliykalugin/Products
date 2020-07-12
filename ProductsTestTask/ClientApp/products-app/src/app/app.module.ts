import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule, HTTP_INTERCEPTORS }    from '@angular/common/http';
import { ProductsListComponent } from './products-list/products-list.component';
import { environment } from 'src/environments/environment';

import { NgSelectModule } from '@ng-select/ng-select';

import { BaseInterceptor } from './Services/base-interceptor';
import { AddProductComponent } from './add-product/add-product.component';
import { CategoriesDropdownComponent } from './categories-dropdown/categories-dropdown.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    AddProductComponent,
    CategoriesDropdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgSelectModule,
    FormsModule
  ],
  providers: [
    { provide: "BASE_API_URL", useValue: environment.apiUrl },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
