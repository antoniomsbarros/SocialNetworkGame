import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

import {Observable, of} from 'rxjs';

import {ConnectionIntroductionDTO} from "../dto/ConnectionIntroductionDTO";
import {TagsDTO} from "../DTO/TagsDTO";
import {CreateIntroductionRequestDto} from "../DTO/CreateIntroductionRequestDto";


@Injectable({
  providedIn: 'root'
})
export class IntroductionRequestService {
  private readonly introductionRequestURL = "http://localhost:5000/api/IntroductionRequest/";
  private readonly TagsURL = "http://localhost:5000/api/Tags/";
  constructor(private http: HttpClient) {
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  client = "1200607@isep.ipp.pt";
  client1="1200608@isep.ipp.pt";
  getIntroductionsPending(): Observable<ConnectionIntroductionDTO[]> {
    return this.http.get<ConnectionIntroductionDTO[]>(this.introductionRequestURL + "playerIntroduction=" + this.client);
  }

  AcceptorrejectIntroduction(connectionIntroductionDTO: ConnectionIntroductionDTO): Observable<ConnectionIntroductionDTO> {
    return this.http.put<ConnectionIntroductionDTO>(this.introductionRequestURL + "playerIntroduction/" + connectionIntroductionDTO.id, connectionIntroductionDTO);
  }


  getIntroductionPendingAprovall(): Observable<ConnectionIntroductionDTO[]>{
    return this.http.get<ConnectionIntroductionDTO[]>(this.introductionRequestURL+"PlayerAproval="+this.client1);
  }
  ApproveDisapproveIntroduction(connectionIntroductionDTO: ConnectionIntroductionDTO):Observable<ConnectionIntroductionDTO>{
    return this.http.put<ConnectionIntroductionDTO>("http://localhost:5000/api/IntroductionRequest/playerapproval/"+connectionIntroductionDTO.id, connectionIntroductionDTO);
  }
  getAllTags(): Observable<TagsDTO[]> {
    return this.http.get<TagsDTO[]>(this.TagsURL+"all/");
  }
  AddIntroductionRequest(connectionIntroductionDTO:CreateIntroductionRequestDto):Observable<CreateIntroductionRequestDto>{
    return this.http.post<CreateIntroductionRequestDto>(this.introductionRequestURL,connectionIntroductionDTO, this.httpOptions);
  }

}
