import { Injectable } from '@angular/core';
import {Products} from './products';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  /* private products: Products[] =[
    new Products('Программирование на C++',"Васильев А.Н.",'https://cdn1.ozone.ru/s3/multimedia-m/wc1200/6065960986.jpg','2016 г.',
    '978-5-699-87445-3',1500,5),
    new Products('Справочник JavaScript',"Никольский А.П.",'https://cdn1.ozone.ru/s3/multimedia-e/wc1200/6067431542.jpg','2018 г.',
    '978-5-94387-333-1',399,13),
    new Products('Изучаем Python',"Лутц Марк",'https://cdn1.ozone.ru/multimedia/wc1200/1037901189.jpg','2019 г.',
    '978-5-907144-52-1',1999,4),
    new Products('Карманный справочник', 'Лутц Марк', 'https://cdn1.ozone.ru/multimedia/wc1200/1027591430.jpg','2016',
    '978-5-907114-60-9', 699, 2),
  ]; */
  private products: Products[] = [];
  private cartProduct:Products[] = [];

  constructor(private http: HttpClient){
    this.http.get('/Product/GetAll').subscribe((data: any) => {
      this.products = data
      console.log(data);
    });
  }

   getAll(){
    return this.products;
  }

  public getCartProduct(){
    return this.cartProduct;
  }

  public AddCart(AddProduct: Products){
    const clone = Object.assign({}, AddProduct)
    let flagIsbn = true;
    this.cartProduct.forEach(product =>{
      if(product.isbn === AddProduct.isbn){
        product.quantity++;
        flagIsbn = false;
      }
    })
    if(flagIsbn){
      clone.quantity = 1;
      this.cartProduct.push(clone);
    }
  }

  public removeCart(product: Products){
    product.quantity --;
    if(product.quantity <=0){
      for(let i = 0; i <this.cartProduct.length; i++){
        if(this.cartProduct[i].isbn === product.isbn){
          this.cartProduct.splice(i, 1);
        }
      }
    }
    for(let i = 0; i <this.products.length; i++){
      if(this.products[i].isbn === product.isbn){
        this.products[i].quantity++;
      }
    }
  }
  public saveProduct() {
    this.http.put('/Product/Save', this.products);
    console.log(this.products);
  }

  public addOrder(order: Object) {
    this.http.post('/Product/AddOrderFile', order);
    this.cartProduct = [];
  }
}
