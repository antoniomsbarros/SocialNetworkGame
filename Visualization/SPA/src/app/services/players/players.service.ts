import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {RegisterPlayerDto} from "../../dto/players/RegisterPlayerDto";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private socialNetwork: string = "http://localhost:5000/api/Players/";

  constructor(private http: HttpClient) {
  }

  registerPlayer(dto: RegisterPlayerDto): Observable<PlayerDto> {
    return this.http.post<PlayerDto>(this.socialNetwork, dto);
  }
}
