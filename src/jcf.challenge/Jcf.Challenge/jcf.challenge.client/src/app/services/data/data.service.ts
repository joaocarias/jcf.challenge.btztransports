import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { BasicInformations } from "../../models/basic-informations.model";
import { Security } from "../../utils/security";
import { Driver } from "../../models/driver";
import { Vehiche } from "../../models/vehicle";

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

  driverGet(id: any) {
    let params = new HttpParams().set("id", id);
    return this.http.get<Driver>(`${this.urlApi}/Driver/Get`, { headers: this.composeHeaders(), params: params });
  }

  driverDelete(id: any) {
    let params = new HttpParams().set("id", id);
    return this.http.delete(`${this.urlApi}/Driver/Delete`, { headers: this.composeHeaders(), params: params });
  }

  driverUpdate(data: any) {
    let params = new HttpParams().set("id", data.id);
    return this.http.put(`${this.urlApi}/Driver/Update`, data, { headers: this.composeHeaders(), params: params });
  }
  
  vehicleGetAll() {
    return this.http.get<Array<Vehiche>>(`${this.urlApi}/Vehicle/GetAll`, { headers: this.composeHeaders() });
  }

  vehicleCreate(data: any) {
    return this.http.post(`${this.urlApi}/Vehicle/Create`, data, { headers: this.composeHeaders() });
  }

  vehicheGet(id: any) {
    let params = new HttpParams().set("id", id);
    return this.http.get<Vehiche>(`${this.urlApi}/Vehicle/Get`, { headers: this.composeHeaders(), params: params });
  }

  vehicleUpdate(data: any) {
    let params = new HttpParams().set("id", data.id);
    return this.http.put(`${this.urlApi}/Vehicle/Update`, data, { headers: this.composeHeaders(), params: params });
  }

  vehicleDelete(id: any) {
    let params = new HttpParams().set("id", id);
    return this.http.delete(`${this.urlApi}/Vehicle/Delete`, { headers: this.composeHeaders(), params: params });
  }

  refuelingGetAll() {
    return this.http.get<Array<Vehiche>>(`${this.urlApi}/Refueling/GetAll`, { headers: this.composeHeaders() });
  }

  refuelingCreate(data: any) {
    return this.http.post(`${this.urlApi}/Refueling/Create`, data, { headers: this.composeHeaders() });
  }

}
