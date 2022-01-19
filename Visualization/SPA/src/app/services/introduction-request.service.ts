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
  private readonly introductionRequestURL = "https://socialnetworkbackend.azurewebsites.net/api/IntroductionRequest/";
  private readonly TagsURL = "https://socialnetworkbackend.azurewebsites.net/api/Tags/";
  constructor(private http: HttpClient) {
    this.getcurrentuser();
  }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  client1="";
  getcurrentuser(){
    this.client1=localStorage.getItem('playeremail')!.trim();
    this.client3=localStorage.getItem('playeremail')!.trim();
  }

  client3=""
  getIntroductionsPending(client:string): Observable<ConnectionIntroductionDTO[]> {
    return this.http.get<ConnectionIntroductionDTO[]>(this.introductionRequestURL + "playerIntroduction=" + client);
  }

  AcceptorrejectIntroduction(connectionIntroductionDTO: ConnectionIntroductionDTO): Observable<ConnectionIntroductionDTO> {
    return this.http.put<ConnectionIntroductionDTO>(this.introductionRequestURL + "playerIntroduction/" + connectionIntroductionDTO.id, connectionIntroductionDTO);
  }

  getIntroductionPendingAprovall(): Observable<ConnectionIntroductionDTO[]>{
    return this.http.get<ConnectionIntroductionDTO[]>(this.introductionRequestURL+"PlayerAproval="+this.client1);
  }
  ApproveDisapproveIntroduction(connectionIntroductionDTO: ConnectionIntroductionDTO):Observable<ConnectionIntroductionDTO>{
    return this.http.put<ConnectionIntroductionDTO>(this.introductionRequestURL+"playerapproval/"+connectionIntroductionDTO.id, connectionIntroductionDTO);
  }
  getAllTags(): Observable<TagsDTO[]> {
    return this.http.get<TagsDTO[]>(this.TagsURL+"all");
  }
  AddIntroductionRequest(connectionIntroductionDTO:CreateIntroductionRequestDto):Observable<CreateIntroductionRequestDto>{
    return this.http.post<CreateIntroductionRequestDto>(this.introductionRequestURL,connectionIntroductionDTO, this.httpOptions);
  }

}
