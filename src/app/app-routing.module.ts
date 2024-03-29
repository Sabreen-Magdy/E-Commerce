import { CategoryFormComponent } from './Component/core/AdminSide/Category/category-form/category-form.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SidebarAdminComponent } from './Component/core/AdminSide/sidebar-admin/sidebar-admin.component';
import { ProductTabelComponent } from './Component/core/AdminSide/products/product-tabel/product-tabel.component';
import { AdminOrderComponent } from './Component/core/AdminSide/admin-order/admin-order.component';
import { CategoryTableComponent } from './Component/core/AdminSide/Category/category-table/category-table.component';
import { ProductFormComponent } from './Component/core/AdminSide/products/product-form/product-form.component';
import { DashboardAdminPageComponent } from './Component/collectionCompent/dashboard-admin-page/dashboard-admin-page.component';
import { HomePageLayoutComponent } from './Component/collectionCompent/home-page-layout/home-page-layout.component';
import { HomePageComponent } from './Component/collectionCompent/home-page/home-page.component';
import { StoreComponent } from './Component/core/Store/store.component';
import { ProductDetailsComponent } from './Component/core/AdminSide/product-details/product-details.component';
import { CartComponent } from './Component/core/cart/cart.component';
import { FavoriteComponent } from './Component/core/favorite/favorite.component';
import { CheckoutComponent } from './Component/core/checkout/checkout.component';
import { ProfileComponent } from './Component/core/ProfilePage/profile/profile.component';
import { ProfiledetaileComponent } from './Component/core/ProfilePage/profiledetaile/profiledetaile.component';
import { EditprofileComponent } from './Component/core/ProfilePage/editprofile/editprofile.component';
import { ActivityComponent } from './Component/core/ProfilePage/activity/activity.component';
import { AnonymousPageComponent } from './Component/core/anonymous-page/anonymous-page.component';
import { SignFamilyComponent } from './Component/collectionCompent/sign-family/sign-family.component';
import { SigninFormComponent } from './Component/core/SignComp/signin-form/signin-form.component';
import { SignUpFormComponent } from './Component/core/SignComp/sign-up-form/sign-up-form.component';
import { ForgetPasswordComponent } from './Component/core/SignComp/forget-password/forget-password.component';
import { AboutComponent } from './Component/core/about/about.component';
import { ComponentUrl } from './models/unit';
import { ReviewsComponent } from './Component/core/anonymous-page/reviews/reviews.component';
import { TableComponent } from './Component/core/AdminSide/general/table/table.component';
import { AuthGuard } from './auth.guard';
import { ProductDetailsmainComponent } from './Component/core/product-details-main/ProductDetailsmainComponent';
import { adminServiceGuard } from './admin-service.guard';


const routes: Routes = [
  {path:"",redirectTo:"main",pathMatch:"full"},
  {path:"admin",canActivate:[adminServiceGuard],component:SidebarAdminComponent, children:[
    {path:"dashboard",canActivate:[adminServiceGuard],component:DashboardAdminPageComponent, },
    {path:"product",canActivate:[adminServiceGuard],component:ProductTabelComponent, },
    {path:"product/add",canActivate:[adminServiceGuard],component:ProductFormComponent, },
    {path:"product/edit/:id",canActivate:[adminServiceGuard],component:ProductFormComponent, },
    {path:"order",canActivate:[adminServiceGuard],component:AdminOrderComponent, },
    {path:"category",canActivate:[adminServiceGuard],component:CategoryTableComponent, },
    {path:"category/add",canActivate:[adminServiceGuard],component:CategoryFormComponent, },
    {path:"category/edit/:id",canActivate:[adminServiceGuard],component:CategoryFormComponent, },
    {path:"Settings",canActivate:[adminServiceGuard],component:TableComponent, },
  ]},
  {path:"",component:HomePageLayoutComponent, children:[
    {path:"main",component:AnonymousPageComponent, },
    {path:"aboutus",component:AboutComponent, },
    { path: ComponentUrl.Reviews, component: ReviewsComponent },
    {path:"",component:SignFamilyComponent,children:[
      {path:"signin",component:SigninFormComponent, },
      {path:"signup",component:SignUpFormComponent, },
      {path:"forgetpassword",component:ForgetPasswordComponent, },
    ]},
    {path:"home",canActivate:[AuthGuard],component:HomePageComponent, },
    {path:"store",canActivate:[AuthGuard],component:StoreComponent, },
    {path:"store/:catgoryname",canActivate:[AuthGuard],component:StoreComponent, },
    {path:"store/products/:productname",canActivate:[AuthGuard],component:StoreComponent, },
    {path:"store/productDetials/:id",canActivate:[AuthGuard],component:ProductDetailsmainComponent, },
    {path:"cart",canActivate:[AuthGuard],component:CartComponent, },
    {path:"favorite",canActivate:[AuthGuard],component:FavoriteComponent, },
    {path:"checkout",canActivate:[AuthGuard],component:CheckoutComponent, },
    {path:"profile",canActivate:[AuthGuard],component:ProfileComponent, children:[
      {path:"profiledetails",canActivate:[AuthGuard],component:ProfiledetaileComponent, },
      {path:"editprofile",canActivate:[AuthGuard],component:EditprofileComponent, },
      {path:"activity",canActivate:[AuthGuard],component:ActivityComponent, },
    ] },

  ]},


];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
