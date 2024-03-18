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
import { MainPageComponent } from './Component/core/main-page/main-page.component';
import { SliderHomeComponent } from './Component/core/HomePage/slider-home/slider-home.component';
import { CategoriesComponent } from './Component/core/HomePage/categories/categories.component';
import { NewProductComponent } from './Component/core/HomePage/new-product/new-product.component';

import { ReviewsComponent } from './Component/core/reviews/reviews.component';
import { AdminComponent } from './Component/core/admin/admin.component';
import { AsideComponent } from './Component/core/aside/aside.component';
// import { ChartsModule } from 'ng2-charts';
//import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SalesChartComponent } from './Component/core/sales-chart/sales-chart.component';
import { CartComponent } from './Component/core/cart/cart.component';
import { FavoriteComponent } from './Component/core/favorite/favorite.component';
import { AboutUsComponent } from './Component/core/about-us/about-us.component';

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
    AboutUsComponent

  ],
  imports: [
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
