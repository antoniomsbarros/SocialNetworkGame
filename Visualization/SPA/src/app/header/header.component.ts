import {Component, OnInit} from '@angular/core';
import {HeaderService} from "../services/header/header.service";
import { PlayersService } from '../services/players/players.service';
import { firstValueFrom, timer } from "rxjs";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isMenuCollapsed = true;

  numberofPlayers: number = 0;

  player: any;
  constructor(private headerService: HeaderService, private playerService: PlayersService) { }

  ngOnInit(): void {
    this.player=localStorage.getItem('playeremail')!.trim();
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
    this.getplayernumber();
  }

  get components() {
    return this.headerService.getComponents();
  }

  async getplayernumber() {
    this.numberofPlayers = await firstValueFrom(this.playerService.getNumberOfPLayers());
  }
}
