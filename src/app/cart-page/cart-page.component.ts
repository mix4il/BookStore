import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Products } from '../products';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.scss']
})
export class CartPageComponent implements OnInit {

  private _productService: any;
  public cartProduct: Products[]= [];
  public totalPrice: any;

  public inputName:String = '';

  constructor(productService: ProductService) {
    this._productService = productService;
  }
  
  ngOnInit(): void {
     this.cartProduct = this._productService.getCartProduct();
     this.totalPrice = this.getTotalPrice()
  }

  getTotalPrice(){
    let sum = 0;
    this.cartProduct.forEach(product=> {
      sum+= +product.quantity * +product.price;
    })
    return sum > 1000 ? Math.round(sum*= 0.95) : sum;
  }

  remove(product: Products): void {
    this._productService.removeCart(product);
  }

  checkout(){
    window.alert("Заказ оформлен!");
  }
}
