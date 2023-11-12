import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { BasicInformations } from "../../models/basic-informations.model";
import { Security } from "../../utils/security";
import { Driver } from "../../models/driver";

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

  authenticate(data: any) {
    return this.http.post(`${this.urlApi}/Account/Login`, data);
  }

  driverGetAll() {
    return this.http.get<Array<Driver>>(`${this.urlApi}/Driver/GetAll`, { headers: this.composeHeaders() });
  }

  driverCreate(data: any)
  {
    return this.http.post(`${this.urlApi}/Driver/Create`, data, { headers: this.composeHeaders() });
  }

  vehicleGetAll() {
    return this.http.get<Array<Driver>>(`${this.urlApi}/Vehicle/GetAll`, { headers: this.composeHeaders() });
  }

  vehicleCreate(data: any) {
    return this.http.post(`${this.urlApi}/Vehicle/Create`, data, { headers: this.composeHeaders() });
  }
}
