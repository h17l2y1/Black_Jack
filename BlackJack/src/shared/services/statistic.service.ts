import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGetAllGamesStatisticView } from '../models/Statistic/RequestGetAllGamesStatisticView';
import { ResponseGetAllGamesStatisticView } from '../models/Statistic/ResponseGetAllGamesStatisticView';
import { ResponseGetGameStatisticView } from '../models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../models/Statistic/RequestGetGameStatisticView';


@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  readonly rootUrl = "http://localhost:52077/";

  constructor(private http:HttpClient) { }

  getAllGames(model : RequestGetAllGamesStatisticView){
    return this.http.post<ResponseGetAllGamesStatisticView>(this.rootUrl + 'api/Statistic/GetAllGames', model);
  }

  getGame(model : RequestGetGameStatisticView){
    return this.http.post<ResponseGetGameStatisticView>(this.rootUrl + 'api/Statistic/GetGame', model);
  }

}
