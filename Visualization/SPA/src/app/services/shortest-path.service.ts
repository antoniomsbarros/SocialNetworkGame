import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {environment} from "../../environments/environment";
import {PathDto} from "../DTO/PathDto";

@Injectable({
  providedIn: 'root'
})
export class ShortestPathService {
  private shortestPathUrl = 'shortestPath';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient) { }

  getShortestPath(userFrom: string, userDest: string): Observable<PathDto> {


    const url = `${this.shortestPathUrl}?userFrom=${userFrom}&userDest=${userDest}`;
    return this.http.get<PathDto>(environment.AIApiUrl+url)
      .pipe(catchError(e => this.handleError(e)));
  }

  private handleError(err : HttpErrorResponse) {

    if(err.error instanceof ErrorEvent){
      console.error('An error occurred: ', err.error.message);
    } else {
      console.error(`Web Api returned code ${err.status}, ` + ` Response body was: ${err.message}`);
    }
    return throwError(() => err);
  }
}
