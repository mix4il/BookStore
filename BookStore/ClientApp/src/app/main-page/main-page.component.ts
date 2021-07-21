import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Products } from '../products';



@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent {
  
  public products: Products [] = [];
  private _productService: ProductService;

  constructor(ProductService: ProductService) {
    this._productService = ProductService;
   }
  ngOnInit(): void {
    this.products = this._productService.getAll();
  }


  share() {
    window.alert('The product has been shared!');
  }
}
