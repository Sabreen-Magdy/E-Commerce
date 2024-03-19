import { AnonymousPageComponent } from './Component/core/anonymous-page/anonymous-page.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './Component/core/cart/cart.component';
import { StoreComponent } from './Component/core/Store/store.component';
import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';
import { CheckoutComponent } from './Component/core/checkout/checkout.component';
import { FavoriteComponent } from './Component/core/favorite/favorite.component';
import { FutureComponentComponent } from './Component/core/future-component/future-component.component';
import { CategoriesComponent } from './Component/core/HomePage/categories/categories.component';
import { NewProductComponent } from './Component/core/HomePage/new-product/new-product.component';
import { SliderHomeComponent } from './Component/core/HomePage/slider-home/slider-home.component';
import { ReviewsComponent } from './Component/core/anonymous-page/reviews/reviews.component';
import { SignUpFormComponent } from './Component/core/SignComp/sign-up-form/sign-up-form.component';
import { SigninFormComponent } from './Component/core/SignComp/signin-form/signin-form.component';
import { ForgetPasswordComponent } from './Component/core/SignComp/forget-password/forget-password.component';
<<<<<<< HEAD:src/app/app-routing.module.ts
import { HomePageComponent } from './Component/core/HomePage/home-page/home-page.component';
import { AboutComponent } from './Component/core/about/about.component';
import { ProfileComponent } from './Component/core/profilePage/profile/profile.component';
import { EditprofileComponent } from './Component/core/profilePage/editprofile/editprofile.component';
import { ProfiledetaileComponent } from './Component/core/profilePage/profiledetaile/profiledetaile.component';
import { ActivityComponent } from './Component/core/profilePage/activity/activity.component';

const routes: Routes = [
  { path: 'cart', component: CartComponent},
  { path: 'mainpage', component: MainPageComponent},
  { path: 'homepage', component: HomePageComponent},
  { path: 'aboutus', component: AboutComponent},
  { path: 'checkout', component:CheckoutComponent},
  { path: 'favorite', component:FavoriteComponent},
  { path: 'future', component:FutureComponentComponent},
  { path: 'categories', component:CategoriesComponent},
  { path: 'newproduct', component:NewProductComponent},
  { path: 'sliderhome', component:SliderHomeComponent},
  { path: 'reviews', component:ReviewsComponent},
  { path: 'profile', component:ProfileComponent},
  { path: 'editprofile', component:EditprofileComponent},
  { path: 'profiledetails', component:ProfiledetaileComponent},
  { path: 'activity', component:ActivityComponent},
  { path: 'signup', component:SignUpFormComponent},
  { path: 'signin', component:SigninFormComponent},
  { path: 'forgetpassword', component:ForgetPasswordComponent},
  { path: 'store', component: StoreComponent},
  { path: 'navbar', component: NavbarComponent},
  { path: 'footer', component: FooterComponent}
=======
import { ComponentUrl } from './models/unit';

const routes: Routes = [
  { path: ComponentUrl.Cart, component: CartComponent },
  { path: ComponentUrl.AnonymousPage, component: AnonymousPageComponent },
  { path: ComponentUrl.AboutUs, component: AboutUsComponent },
  { path: ComponentUrl.Default, component: AboutUsComponent },
  { path: ComponentUrl.Checkout, component: CheckoutComponent },
  { path: ComponentUrl.Favorite, component: FavoriteComponent },
  { path: ComponentUrl.Future, component: FutureComponentComponent },
  { path: ComponentUrl.Categories, component: CategoriesComponent },
  { path: ComponentUrl.NewProduct, component: NewProductComponent },
  { path: ComponentUrl.SliderHome, component: SliderHomeComponent },
  { path: ComponentUrl.Reviews, component: ReviewsComponent },
  { path: ComponentUrl.SignUp, component: SignUpFormComponent },
  { path: ComponentUrl.SignIn, component: SigninFormComponent },
  { path: ComponentUrl.ForgetPassword, component: ForgetPasswordComponent },
  { path: ComponentUrl.Store, component: StoreComponent },
  { path: ComponentUrl.Navbar, component: NavbarComponent },
  { path: ComponentUrl.Footer, component: FooterComponent },
>>>>>>> 9ddbeec8fca41f3659be6533889408d2b25facc5:Front-End/src/app/app-routing.module.ts
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
