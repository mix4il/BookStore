import { Component, OnInit } from '@angular/core';

import {products} from '../products';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent {

  products = products;

  share() {
    window.alert('The product has been shared!');
  }
}
