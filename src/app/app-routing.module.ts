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
import { AllProductDetialsComponent } from './Component/core/AdminSide/EditProduct/all-product-detials/all-product-detials.component';
import { ColorFormComponent } from './Component/core/AdminSide/EditProduct/color-form/color-form.component';
import { VarientFormComponent } from './Component/core/AdminSide/EditProduct/varient-form/varient-form.component';
import { EmailSignFORMComponent } from './Component/core/SignComp/email-sign-form/email-sign-form.component';
import { DeleteComponent } from './Component/core/AdminSide/delete/delete.component';
import { VerifiyComponent } from './Component/core/verifiy/verifiy.component';
import { RestPasswordComponent } from './Component/core/SignComp/rest-password/rest-password.component';
import { UpdatePassComponent } from './Component/core/ProfilePage/update-pass/update-pass.component';


const routes: Routes = [
  {path:"",redirectTo:"home",pathMatch:"full"},
  {path:"admin",canActivate:[adminServiceGuard],component:SidebarAdminComponent, children:[
    {path:"dashboard",canActivate:[adminServiceGuard],component:DashboardAdminPageComponent, },
    {path:"product",canActivate:[adminServiceGuard],component:ProductTabelComponent, },
    {path:"product/add",canActivate:[adminServiceGuard],component:ProductFormComponent, },
    {path:"product/detials/:id",canActivate:[adminServiceGuard],component:AllProductDetialsComponent, },
    {path:"product/detials/AddImage/:id",canActivate:[adminServiceGuard],component:ColorFormComponent, },
    {path:"product/detials/AddVariant/:id",canActivate:[adminServiceGuard],component:VarientFormComponent, },
    {path:"product/details/EditVariant/:id/:variantId", canActivate: [adminServiceGuard], component: VarientFormComponent },
    {path:"order",canActivate:[adminServiceGuard],component:AdminOrderComponent, },
    {path:"category",canActivate:[adminServiceGuard],component:CategoryTableComponent, },
    {path:"category/add",canActivate:[adminServiceGuard],component:CategoryFormComponent, },
    {path:"category/edit/:id",canActivate:[adminServiceGuard],component:CategoryFormComponent, },
    {path:"Settings",canActivate:[adminServiceGuard],component:TableComponent, },
    {path:"customer",canActivate:[adminServiceGuard],component:DeleteComponent, },
  ]},
  {path:"",component:HomePageLayoutComponent, children:[
    {path:"main",component:AnonymousPageComponent, },
    {path:"aboutus",component:AboutComponent, },
    { path: ComponentUrl.Reviews, component: ReviewsComponent },
    {path:"",component:SignFamilyComponent,children:[
      {path:"signin",component:SigninFormComponent, },
      {path:"emailValidation",component:EmailSignFORMComponent, },
      {path:"signup",component:SignUpFormComponent, },
      {path:"forgetpassword",component:ForgetPasswordComponent, },
      {path:"OTP",component:VerifiyComponent, },
      {path:"resetpassword",component:RestPasswordComponent, },
    ]},
    {path:"home",component:HomePageComponent, },
    {path:"home/:catgoryname",component:HomePageComponent, },
    {path:"store",component:StoreComponent, },
    {path:"store/:catgoryname",component:StoreComponent, },
    {path:"store/products/:productname",component:StoreComponent, },
    {path:"store/productDetials/:id",component:ProductDetailsmainComponent, },
    {path:"cart",canActivate:[AuthGuard],component:CartComponent, },
    {path:"favorite",canActivate:[AuthGuard],component:FavoriteComponent, },
    {path:"checkout",canActivate:[AuthGuard],component:CheckoutComponent, },
    {path:"profile",canActivate:[AuthGuard],component:ProfileComponent, children:[
      {path:"profiledetails",canActivate:[AuthGuard],component:ProfiledetaileComponent, },
      {path:"editprofile",canActivate:[AuthGuard],component:EditprofileComponent, },
      {path:"order",canActivate:[AuthGuard],component:ActivityComponent, },
      {path:"updatapassword",canActivate:[AuthGuard],component:UpdatePassComponent, },
    ] },

  ]},


];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
