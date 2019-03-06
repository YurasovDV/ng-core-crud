import { Injectable } from '@angular/core';
import { Category } from '../model/category';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  private apiUrl: string;

  constructor(private httpClient: HttpClient, private config: AppConfig) {
    config.get('ApiPath') + '/category';
  }

  public getAll(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.apiUrl);
  }

  public getCategory(id: Number): Observable<Category> {
    return this.httpClient.get<Category>(this.apiUrl + '/' + id);
  }

  public create(category: Category) {
    return this.httpClient.post(this.apiUrl, category);
  }

  public update(category: Category) {
    return this.httpClient.put(this.apiUrl, category);
  }

  public delete(id: Number) {
    return this.httpClient.delete(this.apiUrl + '/' + id);
  }
}
