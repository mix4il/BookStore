import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import {Products} from '../products'
'/'
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  private _productService;

  @Input() product: any;

  constructor(productService: ProductService) {
    this._productService = productService;
   }

  ngOnInit(): void {
  }

  Add(){
    this._productService.AddCart(this.product);
    this.product.quantity--;
  }
}
