import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestStartGameView } from '../models/Game/requestStartGameView';
import { RequestGetCardGameView } from '../models/Game/requestGetCardGameView';
import { ResponseStartGameView } from '../models/Game/responseStartGameView';
import { ResponseCardGameView } from '../models/Game/responseCardGameView';
import { RequestStopGameView } from '../models/Game/requestStopGameView';
import { ResponseStopGameView } from '../models/Game/responseStopGameView';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  readonly rootUrl = environment.apiUrl;

  response:any;
  constructor(private http:HttpClient) { }

  start(model : RequestStartGameView){
    return this.http.post<ResponseStartGameView>(this.rootUrl + 'Game/StartGame', model);
  }

  getCard(model : RequestGetCardGameView){
    return this.http.get<ResponseCardGameView>(this.rootUrl + 'Game/GetCard/?userId=' + model.userId + "&gameId=" + model.gameId);
  }

  stop(model : RequestStopGameView){
    return this.http.post<ResponseStopGameView>(this.rootUrl + 'Game/Stop', model);
  }
}
