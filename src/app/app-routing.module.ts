import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './Component/core/cart/cart.component';
import { MainPageComponent } from './Component/core/main-page/main-page.component';
import { StoreComponent } from './Component/core/Store/store.component';
import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';
import { AboutUsComponent } from './Component/core/about-us/about-us.component';
import { CheckoutComponent } from './Component/core/checkout/checkout.component';
import { FavoriteComponent } from './Component/core/favorite/favorite.component';
import { FutureComponentComponent } from './Component/core/future-component/future-component.component';
import { CategoriesComponent } from './Component/core/HomePage/categories/categories.component';
import { NewProductComponent } from './Component/core/HomePage/new-product/new-product.component';
import { SliderHomeComponent } from './Component/core/HomePage/slider-home/slider-home.component';
import { ReviewsComponent } from './Component/core/reviews/reviews.component';
import { SignUpFormComponent } from './Component/core/SignComp/sign-up-form/sign-up-form.component';
import { SigninFormComponent } from './Component/core/SignComp/signin-form/signin-form.component';
import { ForgetPasswordComponent } from './Component/core/SignComp/forget-password/forget-password.component';

const routes: Routes = [
  { path: 'cart', component: CartComponent},
  { path: 'mainpage', component: MainPageComponent},
  { path: 'aboutus', component: AboutUsComponent},
  { path: 'checkout', component:CheckoutComponent},
  { path: 'favorite', component:FavoriteComponent},
  { path: 'future', component:FutureComponentComponent},
  { path: 'categories', component:CategoriesComponent},
  { path: 'newproduct', component:NewProductComponent},
  { path: 'sliderhome', component:SliderHomeComponent},
  { path: 'reviews', component:ReviewsComponent},
  { path: 'signup', component:SignUpFormComponent},
  { path: 'signin', component:SigninFormComponent},
  { path: 'forgetpassword', component:ForgetPasswordComponent},
  { path: 'store', component: StoreComponent},
  { path: 'navbar', component: NavbarComponent},
  { path: 'footer', component: FooterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
