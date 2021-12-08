import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AuthenticateUserDto} from "../../dto/users/AuthenticateUserDto";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private user: string = "https://localhost:5001/api/SystemUsers/login/";

  constructor(private http: HttpClient) {
  }

  login(dto: AuthenticateUserDto): Observable<any> {
    return this.http.post<any>(this.user, dto, {
      withCredentials: true
    });
  }

}
