import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FutureComponentComponent } from './Component/core/future-component/future-component.component';

import { NavbarComponent } from './Component/shared/navbar/navbar.component';
import { FooterComponent } from './Component/shared/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { SigninFormComponent } from './Component/signin-form/signin-form.component';
import { SignUpFormComponent } from './Component/sign-up-form/sign-up-form.component';
import { SignImgComponent } from './Component/sign-img/sign-img.component';
import { ForgetPasswordComponent } from './Component/forget-password/forget-password.component';
import { MainPageComponent } from './Component/core/main-page/main-page.component';



@NgModule({
  declarations: [
    AppComponent,

    FutureComponentComponent,

    NavbarComponent,
    FooterComponent,
    SigninFormComponent,
    SignUpFormComponent,
    SignImgComponent,
    ForgetPasswordComponent,

    MainPageComponent



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
