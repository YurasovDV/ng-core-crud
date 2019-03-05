import { Injectable } from '@angular/core';

@Injectable()
export class AppConfig {
  private _config: { [key: string]: string };
  
  constructor() {
    this._config = {
      // build task?
      ApiPath: 'http://localhost:11353/api/v1'
    };
  }

  get(key: any) {
    return this._config[key];
  }
}
