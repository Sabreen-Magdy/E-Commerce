import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar-admin',
  templateUrl: './sidebar-admin.component.html',
  styleUrls: ['./sidebar-admin.component.css']
})
export class SidebarAdminComponent {

  
   
 
 
  // following are the code to change sidebar button(optional)
  menuBtnChange() {
    let sidebar = document.querySelector(".sidebar");
    let closeBtn = document.querySelector("#btn");
    sidebar?.classList.toggle("open");
   if(sidebar?.classList.contains("open")){
     closeBtn?.classList.replace("bx-menu", "bx-menu-alt-right");//replacing the iocns class
   }else {
     closeBtn?.classList.replace("bx-menu-alt-right","bx-menu");//replacing the iocns class
   }
  }
}
