import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { BasicInformations } from "../../models/basic-informations.model";
import { Security } from "../../utils/security";

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public urlApi = 'https://localhost:7063/api';

  constructor(private http: HttpClient) {

  }

  public composeHeaders() {
    const token = Security.getToken();
    const headers = new HttpHeaders().set('Authorization', `bearer ${token}`);
    return headers;
  }

  getInformations() {
    return this.http.get<BasicInformations>(`${this.urlApi}/Home/GetInformations`);
  }

  

}
