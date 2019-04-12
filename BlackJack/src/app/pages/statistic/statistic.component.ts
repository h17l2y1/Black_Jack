import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../../../shared/services/statistic.service';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { RequestGetAllGamesStatisticView } from '../../../shared/models/Statistic/RequestGetAllGamesStatisticView';
import { ResponseGetAllGamesStatisticView } from '../../../shared/models/Statistic/ResponseGetAllGamesStatisticView';
import { ResponseGetGameStatisticView } from '../../../shared/models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../../../shared/models/Statistic/RequestGetGameStatisticView';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {

  allGamesReq = new RequestGetAllGamesStatisticView;
  allGamesRes = new ResponseGetAllGamesStatisticView;
  gameReq = new RequestGetGameStatisticView;
  gameRes = new ResponseGetGameStatisticView; 
  userId: string = null;
  gameId: string = null;
  isGame: boolean = false;

  constructor(private router: Router, private service: StatisticService) { }

  ngOnInit() {
    this.getUserId();
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
