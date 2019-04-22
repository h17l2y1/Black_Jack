import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../../../shared/services/statistic.service';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { ResponseGetGameStatisticView } from '../../../shared/models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../../../shared/models/Statistic/RequestGetGameStatisticView';
import { ResponsePaginationStatisticView } from '../../../shared/models/Statistic/ResponsePaginationStatisticView';
import { RequestPaginationStatisticView } from '../../../shared/models/Statistic/RequestPaginationStatisticView';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {

  gameReq = new RequestGetGameStatisticView;
  gameRes = new ResponseGetGameStatisticView; 
  userId: string = null;
  gameId: string = null;
  isGame: boolean = false;
  public newPage = new ResponsePaginationStatisticView;
  pageNumber : RequestPaginationStatisticView = { page: 1, size: 3 };
  isNext: boolean = true;
  isPrevious: boolean = true;


  constructor(private router: Router, private service: StatisticService) { }

  ngOnInit() {
    this.getUserId();
    this.getStat()
  }

  onBack(){
    this.router.navigateByUrl('choose');
  }

  onFirst(){
    this.pageNumber.page = 1;
    this.getStat();
  }

  onLast(){
    this.pageNumber.page = this.newPage.totalPages;
    this.getStat();
  }

  onGame(gameId:string){
    console.log(gameId);
    this.isGame = true;
    this.gameReq.gameId = gameId;
    this.gameReq.playerId = this.userId;
    this.service.getGame(this.gameReq)
    .subscribe((response) => {
      this.gameRes = response
    })
  }

  checker(){
    if(this.pageNumber.page == this.newPage.totalPages){
      this.isNext = false;
    }
    if(this.pageNumber.page < this.newPage.totalPages){
      this.isNext = true;
    }
    if(this.pageNumber.page == 1){
      this.isPrevious = false;
    }
    if(this.pageNumber.page > 1){
      this.isPrevious = true;
    }
  }

  onStatNext(){
    this.pageNumber.page += 1;
    this.getStat();
  }

  onStatPrevious(){
    this.pageNumber.page -= 1;
    this.getStat();
  }

  getStat(){
    this.checker();
    this.service.getPage(this.pageNumber)
    .subscribe((response) => {
      this.newPage = response
    })
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var tokenClaims = jwt_decode(token, "");
    this.userId = tokenClaims.UserId;
  }

}
