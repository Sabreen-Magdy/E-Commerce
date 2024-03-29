import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { Iproduct } from 'src/app/models/iproduct';
import { IproductShow } from 'src/app/models/i-product-variant';
import { FavoriteService } from 'src/app/services/favorite.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-signin-form',
  templateUrl: './signin-form.component.html',
  styleUrls: ['./signin-form.component.css']
})
export class SigninFormComponent {
  signinform : FormGroup;
  showerror : boolean =false;
  unauthorized : boolean = false;
  signAllproduct : IproductShow[] = [];

  constructor(private _AuthService:AuthService , private _Router:Router,private _fav:FavoriteService,private _cart:CartService){
    this.signinform = new FormGroup({
      email: new FormControl(
        "",
        [
          Validators.required,
          Validators.pattern(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.com$/)
        ]
      ),
      password : new FormControl (
        "",
        [
          Validators.required,
          Validators.minLength(6),
        ]
      ),
    }
    );
  }
ngOnInit():void{
  if(this._AuthService.userData.getValue() != null){
    this._Router.navigate(['/home']);
  }
  this._AuthService.getallProduct();
}





  get emailcontrol(){
    return this.signinform.get('email')
  }
  get passwordcontrol(){
    return this.signinform.get('password')
  }

  errorMessage:string="";
  submitLoginForm(e:Event){
    console.log("start");
      if (this.signinform.valid){

          this._AuthService.signIn(this.signinform.value.email,this.signinform.value.password).subscribe({
            next : (g) => {
              if(this._AuthService.userRole=="Customer "){
                this._Router.navigate(['/home']);
              }else if(this._AuthService.userRole=="Saller "){
                this._Router.navigate(['/admin/dashboard']);
              }
            },
            error : (e) => {
              console.log(e);
              this.unauthorized= true
            }
          })



      }else {
        this.showerror = true;
      }
  }

  ngOnDestroy(){
    this._fav.getNumberOfitemInFavCart();
    this._cart.getNumberOfitemInCart();
  }
}
