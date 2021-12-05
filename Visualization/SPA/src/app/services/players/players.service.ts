import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, of, tap} from "rxjs";
import {PlayerDto} from "../../dto/players/PlayerDto";
import {RegisterPlayerDto} from "../../dto/players/RegisterPlayerDto";
import {UpdateEmotionalStatusDto} from "../../DTO/players/UpdateEmotionalStatusDto";
import {UpdateProfileDto} from "../../DTO/players/UpdateProfileDto";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private socialNetwork: string = "http://localhost:5000/api/Players/";
  private humorState: string = "https://localhost:5001/api/Players/humor/";
  private profile: string = "https://localhost:5001/api/Players/profile/";


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };


  constructor(private http: HttpClient) {
  }

  registerPlayer(dto: RegisterPlayerDto): Observable<PlayerDto> {
    return this.http.post<PlayerDto>(this.socialNetwork, dto);
  }

  updateProfile(dto: UpdateProfileDto): Observable<any> {
    return this.http.put<UpdateProfileDto>(`${this.profile}${dto.email}`, dto);
  }

/*
  changeHumor(dto: UpdateEmotionalStatusDto): Observable<PlayerDto>{
    return this.http.put<PlayerDto>(this.humorState, dto);
  }
 */
  changeHumor(id: string, newMood: string): Observable<any>{
    const url1='https://localhost:5001/api/ChangeMood/';
    const url= `${url1}${id}/${newMood}`;

    return this.http.put(url, this.httpOptions).pipe(
      tap(_=> console.log(`updated player humor, for player id=${id}`)),
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
}
