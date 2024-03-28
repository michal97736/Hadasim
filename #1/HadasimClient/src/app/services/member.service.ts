import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { HttpClient } from '@angular/common/http';
import MemberModel from '../models/MemberModel';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  members: MemberModel[] = []
  constructor(public http: HttpClient) { }
  routeUrl = `${environment.baseUrl}/Member`;

  getAll() {
    return this.http.get<MemberModel[]>(this.routeUrl);
  }

  getById(id: number) {
    return this.http.get<MemberModel>(`${this.routeUrl}/${id}`);
  }

  delete(id: number){
    return this.http.delete<any>(`${this.routeUrl}/${id}`);
  }

  addMember(member: MemberModel) {
    return this.http.post<MemberModel>(`${this.routeUrl}`, member);
  }
  
  updateMember(id:number,member:MemberModel){
    return this.http.put<MemberModel>(`${this.routeUrl}/${id}`,member)
  }

}
