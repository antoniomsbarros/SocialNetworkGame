import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {environment} from "../../environments/environment";
import {PathDto} from "../DTO/PathDto";
import {ShortspathsDTO} from "../DTO/shortspathsDTO";

@Injectable({
  providedIn: 'root'
})
export class ShortestPathService {
  private shortestPathUrl = 'https://socialnetworkai041.westeurope.cloudapp.azure.com/api/network/shortestpath?depth=';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': "*",
    })
  };

  constructor(
    private http: HttpClient) { }

  getShortestPath(depth:string, playersender:string, playerdest:string): Observable<any> {
 // return this.http.get<ShortspathsDTO>(this.shortestPathUrl+depth+"&orig="+playersender+"&dest="+playerdest).pipe(catchError(this.handleError))
    console.log("aqui")
    return this.http.get<any>("https://socialnetworkai041.westeurope.cloudapp.azure.com/api/network/shortestpath?depth=2&orig=pedro@email.com&dest=miguel@email.com",this.httpOptions ).pipe(catchError(this.handleError));
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
