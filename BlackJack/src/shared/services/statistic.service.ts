import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGetGameStatisticView } from '../models/Statistic/responseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../models/Statistic/requestGetGameStatisticView';
import { RequestPaginationStatisticView } from '../models/Statistic/requestPaginationStatisticView';
import { ResponsePaginationStatisticView } from '../models/Statistic/responsePaginationStatisticView';
import { RequestGetUserStatStatisticView } from '../models/Statistic/requestGetUserStatStatisticView';


@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  readonly rootUrl = "http://localhost:52077/";

  constructor(private http:HttpClient) { }

  getGame(model : RequestGetGameStatisticView){
    debugger
    return this.http.post<ResponseGetGameStatisticView>(this.rootUrl + 'api/Statistic/GetGame', model);
  }

  getPage(model: RequestPaginationStatisticView){
    return this.http.post<ResponsePaginationStatisticView>(this.rootUrl + 'api/Statistic/Pagination', model);
  }

  getUserPage(model: RequestGetUserStatStatisticView){
    return this.http.post<ResponsePaginationStatisticView>(this.rootUrl + 'api/Statistic/GetUserStat', model);
  }

}
