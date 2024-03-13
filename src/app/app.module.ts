import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
<<<<<<< HEAD
import { FutureComponentComponent } from './core/future-component/future-component.component';
=======
import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { SigninFormComponent } from './Component/signin-form/signin-form.component';
import { SignUpFormComponent } from './Component/sign-up-form/sign-up-form.component';
import { SignImgComponent } from './Component/sign-img/sign-img.component';
import { ForgetPasswordComponent } from './Component/forget-password/forget-password.component';
import { MainPageComponent } from './Component/core/main-page/main-page.component';

>>>>>>> 3804e1c4a3d8d860085db45a5d8ee2c71833684b

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    FutureComponentComponent
=======
    NavbarComponent,
    FooterComponent,
    SigninFormComponent,
    SignUpFormComponent,
    SignImgComponent,
    ForgetPasswordComponent,

    MainPageComponent


>>>>>>> 3804e1c4a3d8d860085db45a5d8ee2c71833684b
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
