import {Injectable} from '@angular/core';
import {PlayerDto} from "../../dto/players/PlayerDto";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class RelationshipsService {

  private relationships: string = "https://localhost:5001/api/Relationships/";

  constructor(private http: HttpClient) {
  }

  addConnectionWithPlayer(player: PlayerDto) { // Adds the connection with the player
    return this.http.post<PlayerDto>(this.relationships, player);
  }


}
