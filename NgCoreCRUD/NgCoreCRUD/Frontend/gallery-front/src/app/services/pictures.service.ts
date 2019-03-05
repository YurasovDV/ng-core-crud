import { Injectable } from '@angular/core';
import { Picturevm } from '../model/picturevm';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {
  private apiUrl: string;

  constructor(private httpClient: HttpClient, private config: AppConfig) {
    config.get('ApiPath') + '/galleryitem';
  }

  public getAll(): Observable<Picturevm[]> {
    return this.httpClient.get<Picturevm[]>(this.apiUrl);
  }

  public getPicture(id: Number): Observable<Picturevm> {
    return this.httpClient.get<Picturevm>(this.apiUrl + '/' + id);
  }

  public create(picturevm: Picturevm) {
    return this.httpClient.post(this.apiUrl, picturevm);
  }

  public update(picturevm: Picturevm) {
    return this.httpClient.put(this.apiUrl, picturevm);
  }

  public deletePicture(id: Number) {
    return this.httpClient.delete(this.apiUrl + '/' + id);
  }
}
