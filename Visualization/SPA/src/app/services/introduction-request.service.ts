import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

import {Observable, of} from 'rxjs';

import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";


@Injectable({
  providedIn: 'root'
})
export class IntroductionRequestService {
  private readonly introductionRequestURL = "http://localhost:5000/api/IntroductionRequest/";

  constructor(private http: HttpClient) {
  }

  client = "1200607@isep.ipp.pt";

  getIntroductionsPending(): Observable<ConnectionIntroductionDTO[]> {
    return this.http.get<ConnectionIntroductionDTO[]>(this.introductionRequestURL + "playerIntroduction/" + this.client);
  }

  AcceptorrejectIntroduction(connectionIntroductionDTO: ConnectionIntroductionDTO): Observable<ConnectionIntroductionDTO> {
    return this.http.put<ConnectionIntroductionDTO>(this.introductionRequestURL + "playerIntroduction/" + connectionIntroductionDTO.id, connectionIntroductionDTO);
  }
}
