import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FutureComponentComponent } from './Component/core/future-component/future-component.component';
import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SigninFormComponent } from './Component/core/SignComp/signin-form/signin-form.component';
import { SignUpFormComponent } from './Component/core/SignComp/sign-up-form/sign-up-form.component';
import { SignImgComponent } from './Component/core/SignComp/sign-img/sign-img.component';
import { ForgetPasswordComponent } from './Component/core/SignComp/forget-password/forget-password.component';
import { MainPageComponent } from './Component/core/anonymous-page/main-page/main-page.component';
import { SliderHomeComponent } from './Component/core/HomePage/slider-home/slider-home.component';
import { CategoriesComponent } from './Component/core/HomePage/categories/categories.component';
import { NewProductComponent } from './Component/core/HomePage/new-product/new-product.component';

import { ReviewsComponent } from './Component/core/anonymous-page/reviews/reviews.component';
//import { AdminComponent } from './Component/core/admin/admin.component';
//import { AsideComponent } from './Component/core/aside/aside.component';
// import { ChartsModule } from 'ng2-charts';
//import { NgxChartsModule } from '@swimlane/ngx-charts';
//import { SalesChartComponent } from './Component/core/sales-chart/sales-chart.component';
import { CartComponent } from './Component/core/cart/cart.component';
import { FavoriteComponent } from './Component/core/favorite/favorite.component';

import { CheckoutComponent } from './Component/core/checkout/checkout.component';

import { AdminComponent } from './Component/core/AdminSide/admin/admin.component';
import { AsideComponent } from './Component/core/AdminSide/aside/aside.component';
import { SalesChartComponent } from './Component/core/AdminSide/sales-chart/sales-chart.component';
import { StoreComponent } from './Component/core/Store/store.component';

import { SidbarComponent } from './Component/core/AdminSide/sidbar/sidbar.component';
import { DashboardComponent } from './Component/core/AdminSide/dashboard/dashboard.component';
import { AddproductComponent } from './Component/core/AdminSide/addproduct/addproduct.component';
import { AboutComponent } from './Component/core/about/about.component';
import { AdminNavComponent } from './Component/core/AdminSide/admin-nav/AdminNavComponent';
import { ProductDetailsComponent } from './Component/core/AdminSide/product-details/product-details.component';

import { ProfileComponent } from './Component/core/ProfilePage/profile/profile.component';
import { ProfiledetaileComponent } from './Component/core/ProfilePage/profiledetaile/profiledetaile.component';
import { ActivityComponent } from './Component/core/ProfilePage/activity/activity.component';
import { EditprofileComponent } from './Component/core/ProfilePage/editprofile/editprofile.component';
import { ProductDetailsmainComponent } from './Component/core/product-details-main/product-details-main.component';
import { RouterModule } from '@angular/router';
import { AnonymousPageComponent } from './Component/core/anonymous-page/anonymous-page.component';
import { OrdersComponent } from './Component/core/orders/orders.component';
import { CardsComponent } from './Component/core/AdminSide/cards/cards.component';

@NgModule({
  declarations: [
    AppComponent,
    ReviewsComponent,
    FutureComponentComponent,
    FutureComponentComponent,
    NavbarComponent,
    FooterComponent,
    SigninFormComponent,
    SignUpFormComponent,
    SignImgComponent,
    ForgetPasswordComponent,
    MainPageComponent,
    SliderHomeComponent,
    CategoriesComponent,
    NewProductComponent,
    AdminComponent,
    AsideComponent,
    SalesChartComponent,
    CartComponent,
    FavoriteComponent,
    StoreComponent,
    SidbarComponent,
    CheckoutComponent,
    AdminNavComponent,
    DashboardComponent,
    AddproductComponent,
    ProductDetailsComponent,
    AboutComponent,
    ProfileComponent,
    ProfiledetaileComponent,
    ActivityComponent,
    EditprofileComponent,
    ProductDetailsmainComponent,
    AnonymousPageComponent,
    OrdersComponent,
    CardsComponent,
    
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    // ChartsModule
    //BrowserModule,
    // NgxChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
