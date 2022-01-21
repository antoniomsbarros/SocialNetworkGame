import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {TagsDTO} from "../DTO/TagsDTO";
import {environment} from "../../environments/environment";



@Injectable({
  providedIn: 'root'
})
export class TagsService {

  constructor(private http: HttpClient) { }

  private readonly TagsURL =environment.APIUrl+ "/Tags/";

  getAllTags(): Observable<TagsDTO[]> {
    return this.http.get<TagsDTO[]>(this.TagsURL+"all/");
  }
}
