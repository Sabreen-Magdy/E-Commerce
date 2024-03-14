import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './Component/core/main-page/main-page.component';
import { ReviewsComponent } from './Component/core/reviews/reviews.component';

@NgModule({
  declarations: [AppComponent, MainPageComponent, ReviewsComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
