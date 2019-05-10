import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';

import { AccountService } from '../../../shared/services/account.service';
import { GameService } from '../../../shared/services/game.service';
import { ResponseSignUpAccountView } from '../../../shared/models/Account/responseSignUpAccountView';
import { RequestStartGameView } from '../../../shared/models/Game/requestStartGameView';
import { ResponseStartGameView } from '../../../shared/models/Game/responseStartGameView';
import { RequestGetCardGameView } from '../../../shared/models/Game/requestGetCardGameView';
import { ResponseCardGameView } from '../../../shared/models/Game/responseCardGameView';
import { RequestStopGameView } from '../../../shared/models/Game/requestStopGameView';
import { ResponseStopGameView } from '../../../shared/models/Game/responseStopGameView';
import { ResponseWinnerGameView } from '../../../shared/models/Game/responseWinnerGameView';
import { TransferService } from '../../../shared/services/transfer.service';


@Component({ 
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})

export class GameComponent implements OnInit {

  gameControl: FormGroup;
  isNewGame: boolean = false;
  isStop: boolean = false;
  userModel = new ResponseSignUpAccountView;
  startGameModel = new RequestStartGameView;
  gameModel = new ResponseStartGameView;
  getCardModel = new RequestGetCardGameView;
  cardModel = new ResponseCardGameView;
  stopModel = new RequestStopGameView;
  stopGameModel = new ResponseStopGameView;
  winnerModel = new ResponseWinnerGameView;
  transferModel = new ResponseSignUpAccountView;

  constructor(private router: Router, private accountService: AccountService, private gameService: GameService, private transferService: TransferService) { 
    transferService.modelAdded$.subscribe(model => this.onItemAdded(model));
    console.log(this.transferModel);
  }

  ngOnInit() {
    this.getUserData();
  }

  private onItemAdded(model: ResponseSignUpAccountView): void {
    this.transferModel = model;
    console.log(this.transferModel);
  }

  onStopGame(){
    this.isStop = true;
    this.stopModel.userId = this.userModel.userId;
    this.stopModel.gameId = this.gameModel.gameId;
    this.gameService.stop(this.stopModel)    
    .subscribe((response) => {
      this.stopGameModel = response;
      this.gameModel.bots = this.stopGameModel.bots;
      this.gameModel.cardsleft = this.stopGameModel.cardsleft
      this.gameModel.user = this.stopGameModel.user;
      this.winnerModel = this.stopGameModel.winner;
    });
  }

  onAddCard() {
    this.getCardModel.gameId = this.gameModel.gameId;
    this.getCardModel.userId = this.userModel.userId;
    this.gameService.getCard(this.getCardModel)
    .subscribe((response) => {
      this.cardModel = response
      this.gameModel.user.cards.push(this.cardModel);
      this.gameModel.user.score += this.cardModel.value;
      if (this.gameModel.user.score > 21){
        this.onStopGame();
      }
    });
  }

  onStart() {
    this.isStop = false;
    this.startGameModel.userId = this.userModel.userId;
    this.gameService.start(this.startGameModel)
      .subscribe((response) => {
        this.gameModel = response;
        console.log(response);
        console.log(this.gameModel);
      });
    this.getUserData();
    this.isNewGame = true;
  }

  getUserData() {
    var userId = this.accountService.getUserId()
    this.accountService.get(userId)
      .subscribe((response) => {
        this.userModel = response;
      });
  }

}
