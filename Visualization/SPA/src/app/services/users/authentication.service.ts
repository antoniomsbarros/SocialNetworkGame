import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AuthenticateUserDto} from "../../dto/users/AuthenticateUserDto";
import {Observable} from "rxjs";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private user: string = environment.APIUrl+"SystemUsers/login/";

  constructor(private http: HttpClient) {
  }

  login(dto: AuthenticateUserDto): Observable<any> {
    return this.http.post<any>(this.user, dto, {
      withCredentials: true
    });
  }

}
