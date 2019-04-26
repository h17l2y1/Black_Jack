import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestStartGameView } from '../models/Game/requestStartGameView';
import { RequestGetCardGameView } from '../models/Game/requestGetCardGameView';
import { ResponseStartGameView } from '../models/Game/responseStartGameView';
import { ResponseCardGameView } from '../models/Game/responseCardGameView';
import { RequestStopGameView } from '../models/Game/requestStopGameView';
import { ResponseStopGameView } from '../models/Game/responseStopGameView';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  readonly rootUrl = "http://localhost:52077/";

  response:any;
  constructor(private http:HttpClient) { }

  start(model : RequestStartGameView){
    return this.http.post<ResponseStartGameView>(this.rootUrl + 'api/Game/StartGame', model);
  }

  getCard(model : RequestGetCardGameView){
    return this.http.post<ResponseCardGameView>(this.rootUrl + 'api/Game/GetCard', model);
  }

  stop(model : RequestStopGameView){
    return this.http.post<ResponseStopGameView>(this.rootUrl + 'api/Game/Stop', model);
  }
}
