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


const routes: Routes = [
  {path:"",redirectTo:"main",pathMatch:"full"},
  {path:"admin",component:SidebarAdminComponent, children:[
    {path:"dashboard",component:DashboardAdminPageComponent, },
    {path:"product",component:ProductTabelComponent, },
    {path:"product/add",component:ProductFormComponent, },
    {path:"product/edit/:id",component:ProductFormComponent, },
    {path:"order",component:AdminOrderComponent, },
    {path:"category",component:CategoryTableComponent, },
    {path:"category/add",component:CategoryFormComponent, },
    {path:"category/edit/:id",component:CategoryFormComponent, },
  ]},
  {path:"",component:HomePageLayoutComponent, children:[
    {path:"main",component:AnonymousPageComponent, },
    {path:"main/aboutus",component:AboutComponent, },
    { path: ComponentUrl.Reviews, component: ReviewsComponent },
    {path:"main",component:SignFamilyComponent,children:[
      {path:"signin",component:SigninFormComponent, },
      {path:"signup",component:SignUpFormComponent, },
      {path:"forgetpassword",component:ForgetPasswordComponent, },
    ]},
    {path:"home",component:HomePageComponent, },
    {path:"store",component:StoreComponent, },
    {path:"store/{catgoryname}",component:StoreComponent, },
    {path:"store/productDetials/:id",component:ProductDetailsComponent, },
    {path:"cart",component:CartComponent, },
    {path:"favorite",component:FavoriteComponent, },
    {path:"checkout",component:CheckoutComponent, },
    {path:"profile",component:ProfileComponent, children:[
      {path:"profiledetails",component:ProfiledetaileComponent, },
      {path:"editprofile",component:EditprofileComponent, },
      {path:"activity",component:ActivityComponent, },
    ] },
    
  ]},
  // {path:"products",component:, canActivate:  },
  // {path:"products/details/:id",component:, },
  // {path:"products/add",component:ProductFormComponent, canActivate: [authenticationGuard, adminGuard]},
  // {path:"products/edit/:id",component:ProductFormComponent, canActivate: [authenticationGuard, adminGuard]},
  // {path:"login",component:LoginComponent},
  // {path:"contacts",component:ContactsComponent},
  // {path:"accounts", component:AccountsComponent, canActivate:[authenticationGuard, adminGuard]},
  // {path:"accounts/add", component:AddAccountComponent, canActivate:[authenticationGuard, adminGuard]},
  // {path:"accounts/edit/:id", component:AddAccountComponent, canActivate:[authenticationGuard, adminGuard]},
  // {path:"**",component:NotFoundComponent},

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}