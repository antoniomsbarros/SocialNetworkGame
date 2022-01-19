import  {map} from "rxjs/operators";
import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Size} from "three/examples/jsm/utils/ShadowMapViewer";

@Injectable({providedIn: 'root'})
export class networkSizeService {
  private url = "https://localhost:5001/api/NetworkSize/"; // URL to web api

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {
  }

  consultNetworkSize(id: string, lvl: string): Observable<any>{
    const url = `${this.url}ConsultNetworkLength=playerID=${id}&level=${lvl}`;
    return this.http.get<Size>(url).pipe(map(response => {
      return response
    }));
  }
}
