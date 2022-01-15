import {Injectable} from '@angular/core';
import {PlayerDto} from "../../dto/players/PlayerDto";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {RelationshipDto} from "../../DTO/relationships/RelationshipDto";
import {PlayerFriendsDTO} from "../../DTO/relationships/PlayerFriendsDTO";


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
  getRelactionPLayer(email: string):Observable<RelationshipDto[]>{
    return this.http.get<RelationshipDto[]>(this.relationships+email+"/relactionships");
  }
  getFriendsFriends(email:string):Observable<PlayerFriendsDTO[]>{
    return this.http.get<PlayerFriendsDTO[]>(this.relationships+email+"/friends/friends");
  }

}
