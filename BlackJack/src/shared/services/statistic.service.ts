import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGetGameStatisticView } from '../models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../models/Statistic/RequestGetGameStatisticView';
import { RequestPaginationStatisticView } from '../models/Statistic/RequestPaginationStatisticView';
import { ResponsePaginationStatisticView } from '../models/Statistic/ResponsePaginationStatisticView';


@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  readonly rootUrl = "http://localhost:52077/";

  constructor(private http:HttpClient) { }

  getGame(model : RequestGetGameStatisticView){
    return this.http.post<ResponseGetGameStatisticView>(this.rootUrl + 'api/Statistic/GetGame', model);
  }

  getPage(model: RequestPaginationStatisticView){
    return this.http.post<ResponsePaginationStatisticView>(this.rootUrl + 'api/Statistic/Pagination', model);

  }

}
