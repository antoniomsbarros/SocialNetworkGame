import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PlayerEmailDto} from "../DTO/PlayerEmailDto";
import {NetworkFromPlayerPerspectiveDto} from "../dto/relationships/NetworkFromPlayerPerspectiveDto";
import {PathDto} from "../DTO/PathDto";

@Injectable({
  providedIn: 'root'
})
export class RelactionShipServiceService {

  constructor(private http: HttpClient) {
  }

  private readonly relationURL = "http://localhost:5000/api/Relationships/"

  getAllFriendsFromPlayer(playeremail: string): Observable<PlayerEmailDto[]> {
    return this.http.get<PlayerEmailDto[]>(this.relationURL + "friends/" + playeremail);
  }

  getNetworkFromPlayerByDepth(playerEmail: string, depth: number): Observable<NetworkFromPlayerPerspectiveDto> {
    return this.http.get<NetworkFromPlayerPerspectiveDto>(`${this.relationURL}network/${playerEmail}/${depth}`);
  }

  getSafestPath(playerEmail: any) {
    return this.http.get<PathDto>(`${this.relationURL}network/safest-path/${playerEmail}`);
  }
}
