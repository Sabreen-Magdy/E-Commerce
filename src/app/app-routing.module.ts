import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './Component/core/cart/cart.component';
import { MainPageComponent } from './Component/core/main-page/main-page.component';
import { StoreComponent } from './Component/core/Store/store.component';
import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';

const routes: Routes = [
  { path: 'cart', component: CartComponent },
  { path: 'mainpage', component: MainPageComponent },
  { path: 'store', component: StoreComponent },
  { path: 'navbar', component: NavbarComponent },
  { path: 'footer', component: FooterComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}