import {Component, OnInit} from '@angular/core';
import {HeaderService} from "../services/header/header.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isMenuCollapsed = true;

  constructor(private headerService: HeaderService) {
  }

  ngOnInit(): void {
    this.headerService.setComponents([{
        name: "Login",
        routerLink: "/login",
        current: true
      },
        {
          name: "Sign Up",
          routerLink: "/signin",
          current: true
        }]
    )
  }

  get components() {
    return this.headerService.getComponents();
  }

}
