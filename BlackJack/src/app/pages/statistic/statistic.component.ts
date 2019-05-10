import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../../../shared/services/statistic.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ResponseGetGameStatisticView } from '../../../shared/models/Statistic/responseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../../../shared/models/Statistic/requestGetGameStatisticView';
import { ResponsePaginationStatisticView } from '../../../shared/models/Statistic/responsePaginationStatisticView';
import { RequestPaginationStatisticView } from '../../../shared/models/Statistic/requestPaginationStatisticView';
import { RequestGetUserStatStatisticView } from '../../../shared/models/Statistic/requestGetUserStatStatisticView';
import { ResponseCardStatisticView } from '../../../shared/models/Statistic/responseCardStatisticView';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
  
  public totalPage : RequestPaginationStatisticView = { page: 1, size: 3 };
  public userPage : RequestGetUserStatStatisticView = { page: 1, size: 3, userName: null };
  public newPage = new ResponsePaginationStatisticView;
  gameReq = new RequestGetGameStatisticView;
  public gameRes = new ResponseGetGameStatisticView; 
  userId: string = null;
  gameId: string = null;
  isGame: boolean = false;
  isNext: boolean = true;
  isPrevious: boolean = true;
  isUser: boolean = false;
  isUserNotFound: boolean = false;
  statisticForm: FormGroup;
  cards: Array<ResponseCardStatisticView> = null;

  constructor(private router: Router, private service: StatisticService, private fb: FormBuilder) { }

  ngOnInit() {
    this.statistic();
  }

  statistic(){
    if (this.userPage.userName == "" || this.userPage.userName == null) {
      this.isUserNotFound = false;
      return this.totalStat();
    }
    this.userStat();
  }

  onFirst(){
    this.totalPage.page = 1;
    this.userPage.page = 1;
    this.statistic();
  }

  onLast(){
    this.totalPage.page = this.newPage.totalPages;
    this.userPage.page = this.newPage.totalPages;
    this.statistic();
  }

  onStatNext(){
    this.totalPage.page += 1;
    this.userPage.page += 1;
    this.statistic();
  }

  onStatPrevious(){
    this.totalPage.page -= 1;
    this.userPage.page -= 1;
    this.statistic();
  }

  checker(){
    if(this.totalPage.page == this.newPage.totalPages){
      this.isNext = false;
    }
    if(this.totalPage.page < this.newPage.totalPages){
      this.isNext = true;
    }
    if(this.totalPage.page == 1){
      this.isPrevious = false;
    }
    if(this.totalPage.page > 1){
      this.isPrevious = true;
    }
  }

  userStat(){
    this.checker();
    this.service.getUserPage(this.userPage)
    .subscribe(
      data =>  {
        console.log(data);
        this.newPage = data
        this.isUserNotFound = false;
      },
      error => {
        if(error.status == 500){
          console.log("User Not Found");
          this.isUserNotFound = true;
          this.totalStat();
        }
      }   
    );
  }

  totalStat(){
    this.checker();
    this.service.getPage(this.totalPage)
    .subscribe((response) => {
      this.newPage = response
    })
  }

  onGame(gameId:string, userName: string){
    debugger
    this.isGame = true;
    this.gameReq.gameId = gameId;
    this.gameReq.userName = userName;
    this.service.getGame(this.gameReq)
    .subscribe((response) => {
      this.gameRes = response
      console.log(response);
    })
  }

  onBack(){
    this.router.navigateByUrl('choose');
  }

}
