import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, firstValueFrom, mergeAll, Observable, of, tap, withLatestFrom} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {RegisterPlayerDto} from "../../dto/players/RegisterPlayerDto";
import {UpdateEmotionalStatusDto} from "../../DTO/players/UpdateEmotionalStatusDto";
import {UpdateProfileDto} from "../../DTO/players/UpdateProfileDto";
import {TagsDTO} from "../../DTO/TagsDTO";
import {TagCloud} from "../../DTO/TagCloud";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private socialNetwork: string = "https://localhost:5001/api/Players/";
  private humorState: string = "https://localhost:5001/api/Players/humor/";
  private profile: string = "https://localhost:5001/api/Players/profile/";
  private getprofile: string = "https://localhost:5001/api/Players/email";
  private getTagsPlayers: string = "https://localhost:5001/api/Players/Tags/"
  private getnumberofplayer: string = "https://localhost:5001/api/Players/numberPlayers/"

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {
  }

  registerPlayer(dto: RegisterPlayerDto): Observable<PlayerDto> {
    return this.http.post<PlayerDto>(this.socialNetwork, dto);
  }

  updateProfile(dto: UpdateProfileDto, email: string): Observable<any> {
    console.log(dto.email);
    console.log(dto.tags)
    return this.http.put<UpdateProfileDto>(this.profile + email, dto);
  }

  getConnectionSuggestion(): Observable<any> {
    return this.http.get<PlayerDto[]>(this.socialNetwork);
  }

  getProfile(email: string): Observable<any> {
    return this.http.get<PlayerDto>(this.getprofile + "=" + email);
  }

  /*
    changeHumor(dto: UpdateEmotionalStatusDto): Observable<PlayerDto>{
      return this.http.put<PlayerDto>(this.humorState, dto);
    }
   */

  changeHumor(id: string, newMood: string): Observable<any> {
    const url1 = 'https://localhost:5001/api/ChangeMood/';
    const url = `${url1}${id}/${newMood}`;

    return this.http.put(url, this.httpOptions).pipe(
      tap(_ => console.log(`updated player humor, for player id=${id}`)),
      catchError(this.handleError<any>('changeHumor'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getPlayersTags(email: string): Observable<TagsDTO[]> {
    return this.http.get<TagsDTO[]>(this.getTagsPlayers + email);
  }

  getNumberOfPLayers(): Observable<number> {
    return this.http.get<number>(this.getnumberofplayer);
  }


  networkLength(): Observable<number> {
    const url = 'https://lapr5backend.azurewebsites.net/api/NerworkLength';
    return this.http.get<number>(url).pipe(tap(_ =>console.log('fetched network length')),
      catchError(this.handleError<number>('getNetworkLength',0))
    );
  }


  getTagCloudFromPlayers(): Observable<TagCloud[]> {
    const url = `${this.socialNetwork}/TagCloud`;
    return this.http.get<TagCloud[]>(url, this.httpOptions)
      .pipe(tap(_ => console.log(`fetched getTagCloudFromPlayers`)),
        catchError(this.handleError<TagCloud[]>(`getTagCloudFromPlayers`,[]))
      );

  }
}
