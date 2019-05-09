import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGetGameStatisticView } from '../models/Statistic/responseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../models/Statistic/requestGetGameStatisticView';
import { RequestPaginationStatisticView } from '../models/Statistic/requestPaginationStatisticView';
import { ResponsePaginationStatisticView } from '../models/Statistic/responsePaginationStatisticView';
import { RequestGetUserStatStatisticView } from '../models/Statistic/requestGetUserStatStatisticView';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  readonly rootUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getGame(model : RequestGetGameStatisticView){
    return this.http.get<ResponseGetGameStatisticView>(this.rootUrl + 'Statistic/GetGame/' + model.userName + "?gameId=" + model.gameId);
  }

  getPage(model: RequestPaginationStatisticView){
    return this.http.get<ResponsePaginationStatisticView>(this.rootUrl + 'Statistic/GetPagination/' + model.page + "?size=" + model.size);
  }

  getUserPage(model: RequestGetUserStatStatisticView){
    return this.http.get<ResponsePaginationStatisticView>(this.rootUrl + 'Statistic/GetUserStat/' + model.page + "?size=" + model.size + "&userName=" + model.userName);
  }

}
