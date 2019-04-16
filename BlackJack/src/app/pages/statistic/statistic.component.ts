import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../../../shared/services/statistic.service';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { RequestGetAllGamesStatisticView } from '../../../shared/models/Statistic/RequestGetAllGamesStatisticView';
import { ResponseGetAllGamesStatisticView } from '../../../shared/models/Statistic/ResponseGetAllGamesStatisticView';
import { ResponseGetGameStatisticView } from '../../../shared/models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../../../shared/models/Statistic/RequestGetGameStatisticView';
import { Response } from 'selenium-webdriver/http';
import { ResponsePaginationStatisticView } from '../../../shared/models/Statistic/ResponsePaginationStatisticView';
import { RequestPaginationStatisticView } from '../../../shared/models/Statistic/RequestPaginationStatisticView';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {

  allGamesReq = new RequestGetAllGamesStatisticView;
  public allGamesRes = new ResponseGetAllGamesStatisticView;
  gameReq = new RequestGetGameStatisticView;
  gameRes = new ResponseGetGameStatisticView; 
  userId: string = null;
  gameId: string = null;
  isGame: boolean = false;
  public gamesList = new ResponsePaginationStatisticView;
  fromNumber : RequestPaginationStatisticView = { from: 0 };

  constructor(private router: Router, private service: StatisticService) { }

  ngOnInit() {
    this.getUserId();
    this.service.getTest(this.fromNumber)
    this.getStat()
  }

  onStatPlus(){
    this.fromNumber.from += 3;
    this.getStat()
  }

  getStat(){
    this.service.getTest(this.fromNumber)
    .subscribe((response) => {
      this.gamesList = response
      console.log(this.gameRes);
    })
  }

  onGame(gameId:string){
    this.isGame = true;
    this.gameReq.gameId = gameId;
    this.gameReq.playerId = this.userId;
    this.service.getGame(this.gameReq)
    .subscribe((response) => {
      this.gameRes = response
      console.log(this.gameRes);
    })
  }

  onAllGames(){
    this.allGamesReq.playerId = this.userId;
    this.service.getAllGames(this.allGamesReq)
    .subscribe((response) => {
      this.allGamesRes = response
    });
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var tokenClaims = jwt_decode(token, "");
    this.userId = tokenClaims.UserId;
  }

  onBack(){
    this.router.navigateByUrl('game');
  }

}
