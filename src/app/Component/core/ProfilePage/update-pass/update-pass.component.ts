import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-update-pass',
  templateUrl: './update-pass.component.html',
  styleUrls: ['./update-pass.component.css']
})
export class UpdatePassComponent {

  editProfileForm : FormGroup=new FormGroup({});
  showerror : boolean = false;
  constructor(private _AuthService:AuthService,private _Router:Router){
    this.MakeFormValidation()
  }
  ngOnInit(): void {
    this.getDataOfUser()
  }
  idValue:number =0
  oldPassValue:string =""
  newPassValue:string =""
  getDataOfUser(){
    this._AuthService.userData.subscribe({
      next:()=>{
        if(this._AuthService.userData.getValue()!=null){
          this._AuthService.getDataOfUser().subscribe(
            { next:(response)=>{
                this.idValue= response.id;
                this.MakeFormValidation()
          }
        });
        }
      }
    });
  }
MakeFormValidation(){
  this.editProfileForm = new FormGroup({
    oldpassword : new FormControl (
      this.oldPassValue,
      [
        Validators.required,
        Validators.minLength(5),
      ]
    ),
    newpassword : new FormControl (
      this.newPassValue,
      [
        Validators.required,
        Validators.minLength(5),
      ]
    ),
  }
  );
}
   enter(e:Event){
    console.log(this.editProfileForm.valid);
   }


  get oldPasscontrol(){
    return this.editProfileForm.get('oldpassword')
  }
  get newPasscontrol(){
    return this.editProfileForm.get('newpassword')
  }
  editForm(e : Event){
    e.preventDefault();
    if (this.editProfileForm.valid){
      let newData={
          id: this.idValue,
          oldPassword: this.editProfileForm.get('oldpassword')?.value,
          newPassword: this.editProfileForm.get('newpassword')?.value
      }
      console.log(newData);

      this._AuthService.updatePassWord(newData).subscribe({
        next:(response)=>{
          this._AuthService.signOut();
          this._Router.navigate(['/signin']);
        },
        error : (e) => {
          console.log(e);
        }
      })
    }
    else{
      this.showerror = true
    }


  }
}
