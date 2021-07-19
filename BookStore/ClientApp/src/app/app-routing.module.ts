import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import { MainPageComponent } from './main-page/main-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { MainLayoutComponent } from './shared/main-layout/main-layout.component';


const childrenRoutes: Routes = [
  { path: '', redirectTo:"/", pathMatch: 'full'},
  { path: '', component: MainPageComponent},
  { path: 'product/:id', component: ProductPageComponent},
  { path: 'cart', component: CartPageComponent}
]

const routes: Routes = [
  {path: '', component:MainLayoutComponent , children: childrenRoutes},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
