import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateDirectRequestDto} from "../../dto/directrequests/CreateDirectRequestDto";
import {Observable} from "rxjs";
import {DirectRequestDto} from "../../dto/directrequests/DirectRequestDto";

@Injectable({
  providedIn: 'root'
})
export class DirectRequestService {

  private socialNetwork: string = "https://localhost:5000/api/DirectRequests/";

  constructor(private http: HttpClient) {
  }

  createDirectRequest(dto: CreateDirectRequestDto): Observable<DirectRequestDto> {
    return this.http.post<DirectRequestDto>(this.socialNetwork, dto);
  }

}
