import { Injectable } from '@angular/core';
import { GoodsType } from './goods-type.model';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GoodsTypeService {

  formData: GoodsType = new GoodsType();
  readonly baseURL = 'http://localhost:5114/api/GoodsType';
  list: GoodsType[];

  constructor(private http: HttpClient) { }

  PostGoodsTypeDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  PutGoodsTypetDetail() {
    return this.http.put(this.baseURL, this.formData);
  }

  DeleteGoodsType(id: number) {
    return this.http.delete(`${this.baseURL}/?numGoodsTypeID=${id}`);
  }

  GetGoodsTypeDetails(): Observable<any> {
    return this.http.get<any>(this.baseURL).pipe();
  }
}
