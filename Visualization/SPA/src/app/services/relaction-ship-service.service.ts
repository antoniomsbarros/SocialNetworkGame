import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PlayerEmailDto} from "../DTO/PlayerEmailDto";

@Injectable({
  providedIn: 'root'
})
export class RelactionShipServiceService {

  constructor(private http: HttpClient) { }
  private readonly relactionURL="http://localhost:5000/api/Relationships/"


  getallfriends(playeremail:string):Observable<PlayerEmailDto[]>{
      return this.http.get<PlayerEmailDto[]>(this.relactionURL+"friends/"+playeremail);
}

}
