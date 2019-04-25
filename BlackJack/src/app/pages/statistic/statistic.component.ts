import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../../../shared/services/statistic.service';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";
import { ResponseGetGameStatisticView } from '../../../shared/models/Statistic/ResponseGetGameStatisticView';
import { RequestGetGameStatisticView } from '../../../shared/models/Statistic/RequestGetGameStatisticView';
import { ResponsePaginationStatisticView } from '../../../shared/models/Statistic/ResponsePaginationStatisticView';
import { RequestPaginationStatisticView } from '../../../shared/models/Statistic/RequestPaginationStatisticView';
import { RequestGetUserStatStatisticView } from '../../../shared/models/Statistic/RequestGetUserStatStatisticView';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
  
  totalPage : RequestPaginationStatisticView = { page: 1, size: 3 };
  userPage : RequestGetUserStatStatisticView = { page: 1, size: 3, userName: null };
  public newPage = new ResponsePaginationStatisticView;
  gameReq = new RequestGetGameStatisticView;
  gameRes = new ResponseGetGameStatisticView; 
  userId: string = null;
  gameId: string = null;
  isGame: boolean = false;
  isNext: boolean = true;
  isPrevious: boolean = true;
  isUser: boolean = false;
  statisticForm: FormGroup;
  constructor(private router: Router, private service: StatisticService, private fb: FormBuilder) { }

  ngOnInit() {
    this.statistic();
  }

  statistic(){
    if (this.userPage.userName == "" || this.userPage.userName == null) {
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
      },
      error => {
        if(error.status == 500){
          console.log("User Not Found");
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

  onBack(){
    this.router.navigateByUrl('choose');
  }

}









// ngOnInit() {
//   this.initForm();
//   this.statistic();
// }

  // initForm(){
  //   this.statisticForm = this.fb.group({
  //     Page: 1,
  //     Size: 3,
  //     Name: [null],
  //     First: [],
  //     Previous: 0,
  //     Next: 0,
  //     Last: 0
  //   });
  // }

  // onSelect(){
  //   this.userPage = this.statisticForm.value.Name
  //   console.log(this.userPage);
  // }






  // statistic(){
  //   if (this.statisticForm.value.Name == "" || this.statisticForm.value.Name == null) {
  //     return this.totalStat();
  //   }
  //   this.userStat();
  // }

  // onFirst(){
  //   this.totalPage.page = 1;
  //   this.userPage.page = 1;
  //   this.statistic();
  // }

  // onLast(){
  //   this.totalPage.page = this.newPage.totalPages;
  //   this.userPage.page = this.newPage.totalPages;
  //   this.statistic();
  // }

  // onStatNext(){
  //   this.totalPage.page += 1;
  //   this.userPage.page += 1;
  //   this.statistic();
  // }

  // onStatPrevious(){
  //   this.totalPage.page -= 1;
  //   this.userPage.page -= 1;
  //   this.statistic();
  // }

  // checker(){
  //   if(this.totalPage.page == this.newPage.totalPages){
  //     this.isNext = false;
  //   }
  //   if(this.totalPage.page < this.newPage.totalPages){
  //     this.isNext = true;
  //   }
  //   if(this.totalPage.page == 1){
  //     this.isPrevious = false;
  //   }
  //   if(this.totalPage.page > 1){
  //     this.isPrevious = true;
  //   }
  // }

  // userStat(){
  //   this.checker();
  //   this.service.getUserPage(this.userPage)
  //   .subscribe(
  //     data =>  {
  //       console.log(data);
  //       this.newPage = data
  //     },
  //     error => {
  //       if(error.status == 500){
  //         console.log("User Not Found");
  //         this.totalStat();
  //       }
  //     }   
  //   );
  // }

  // totalStat(){
  //   this.checker();
  //   this.service.getPage(this.totalPage)
  //   .subscribe((response) => {
  //     this.newPage = response
  //   })
  // }

  // onGame(gameId:string){
  //   console.log(gameId);
  //   this.isGame = true;
  //   this.gameReq.gameId = gameId;
  //   this.gameReq.playerId = this.userId;
  //   this.service.getGame(this.gameReq)
  //   .subscribe((response) => {
  //     this.gameRes = response
  //   })
  // }

  // onBack(){
  //   this.router.navigateByUrl('choose');
  // }
