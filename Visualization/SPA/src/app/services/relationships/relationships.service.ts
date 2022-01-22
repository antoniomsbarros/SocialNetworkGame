import {Injectable} from '@angular/core';
import {PlayerDto} from "../../dto/players/PlayerDto";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, of, tap} from "rxjs";
import {RelationshipDto} from "../../DTO/relationships/RelationshipDto";
import {PlayerFriendsDTO} from "../../DTO/relationships/PlayerFriendsDTO";
import {TagCloud} from "../../DTO/TagCloud";
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RelationshipsService {

  private relationships: string = environment.APIUrl+"Relationships/";

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

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

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getTagCloudFromRelationships(): Observable<TagCloud[]> {
    const url = this.relationships+'TagCloud';
    return this.http.get<TagCloud[]>(url, this.httpOptions)
      .pipe(tap(_ => console.log(`fetched getTagCloudFromRelationships`)),
        catchError(this.handleError<TagCloud[]>(`getTagCloudFromRelationships`,[]))
      );
  }

  updateRelationship(relationshipDto: RelationshipDto): Observable<RelationshipDto> {
    return this.http.put<RelationshipDto>(this.relationships, relationshipDto)
  }
}
