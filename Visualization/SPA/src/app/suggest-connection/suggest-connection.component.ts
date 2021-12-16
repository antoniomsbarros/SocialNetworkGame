import {Component, OnInit} from '@angular/core';
import {PlayersService} from "../services/players/players.service";

@Component({
  selector: 'app-suggest-connection',
  templateUrl: './suggest-connection.component.html',
  styleUrls: ['./suggest-connection.component.css']
})
export class SuggestConnectionComponent implements OnInit {

  constructor(private playerService: PlayersService) {
  }

  get connectionSuggestions() { // returns a list of suggestions for the user in the front-end
    return this.playerService.getConnectionSuggestion();
  }

  ngOnInit(): void {
  }


}
