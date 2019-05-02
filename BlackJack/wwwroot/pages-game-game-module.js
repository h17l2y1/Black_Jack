(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["pages-game-game-module"],{

/***/ "./src/app/pages/game/game-routing.module.ts":
/*!***************************************************!*\
  !*** ./src/app/pages/game/game-routing.module.ts ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var game_component_1 = __webpack_require__(/*! ./game.component */ "./src/app/pages/game/game.component.ts");
var routes = [
    { path: '', component: game_component_1.GameComponent }
];
var GameRoutingModule = /** @class */ (function () {
    function GameRoutingModule() {
    }
    GameRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forChild(routes)],
            exports: [router_1.RouterModule]
        })
    ], GameRoutingModule);
    return GameRoutingModule;
}());
exports.GameRoutingModule = GameRoutingModule;


/***/ }),

/***/ "./src/app/pages/game/game.component.css":
/*!***********************************************!*\
  !*** ./src/app/pages/game/game.component.css ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".userData{\r\n    background-color: rgb(197, 233, 233);\r\n    padding: 10px;\r\n    width: 320px;\r\n}\r\n.userLine{\r\n    margin: 10px;\r\n}\r\n.selector{\r\n    background-color: rgb(178, 214, 214);\r\n    padding: 10px;\r\n    width: 320px;\r\n}\r\n.option{\r\n    margin: 10px;\r\n}\r\n.game{\r\n    display: flex;\r\n    justify-content: space-between;\r\n    flex-wrap: wrap;\r\n    align-items:stretch;\r\n    background-color: darkgreen;\r\n    color: white;\r\n    padding: 10px;\r\n}\r\n.player{\r\n    background-color: rgb(0, 43, 16);\r\n    padding: 4px;\r\n    margin: 10px;\r\n    /* width: 320px; */\r\n\r\n}\r\n.playerProp{\r\n    display: flex;\r\n    justify-content: space-between;\r\n    flex-grow: inherit;\r\n    margin: 10px;\r\n}\r\n.card{\r\n    background-color: azure; \r\n    justify-content: space-between;\r\n    padding: 4px;\r\n    margin: 10px;\r\n\r\n}\r\n.cardProp{\r\n    color: black;\r\n    margin: 10px;\r\n}\r\n.gameButtons{\r\n    display: flex;\r\n}\r\n.btStop{\r\n    margin-left: 20px;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvZ2FtZS9nYW1lLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxvQ0FBb0M7SUFDcEMsYUFBYTtJQUNiLFlBQVk7QUFDaEI7QUFDQTtJQUNJLFlBQVk7QUFDaEI7QUFFQTtJQUNJLG9DQUFvQztJQUNwQyxhQUFhO0lBQ2IsWUFBWTtBQUNoQjtBQUNBO0lBQ0ksWUFBWTtBQUNoQjtBQUVBO0lBQ0ksYUFBYTtJQUNiLDhCQUE4QjtJQUM5QixlQUFlO0lBQ2YsbUJBQW1CO0lBQ25CLDJCQUEyQjtJQUMzQixZQUFZO0lBQ1osYUFBYTtBQUNqQjtBQUVBO0lBQ0ksZ0NBQWdDO0lBQ2hDLFlBQVk7SUFDWixZQUFZO0lBQ1osa0JBQWtCOztBQUV0QjtBQUVBO0lBQ0ksYUFBYTtJQUNiLDhCQUE4QjtJQUM5QixrQkFBa0I7SUFDbEIsWUFBWTtBQUNoQjtBQUVBO0lBQ0ksdUJBQXVCO0lBQ3ZCLDhCQUE4QjtJQUM5QixZQUFZO0lBQ1osWUFBWTs7QUFFaEI7QUFFQTtJQUNJLFlBQVk7SUFDWixZQUFZO0FBQ2hCO0FBRUE7SUFDSSxhQUFhO0FBQ2pCO0FBRUE7SUFDSSxpQkFBaUI7QUFDckIiLCJmaWxlIjoic3JjL2FwcC9wYWdlcy9nYW1lL2dhbWUuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi51c2VyRGF0YXtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IHJnYigxOTcsIDIzMywgMjMzKTtcclxuICAgIHBhZGRpbmc6IDEwcHg7XHJcbiAgICB3aWR0aDogMzIwcHg7XHJcbn1cclxuLnVzZXJMaW5le1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG59XHJcblxyXG4uc2VsZWN0b3J7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiByZ2IoMTc4LCAyMTQsIDIxNCk7XHJcbiAgICBwYWRkaW5nOiAxMHB4O1xyXG4gICAgd2lkdGg6IDMyMHB4O1xyXG59XHJcbi5vcHRpb257XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbn1cclxuXHJcbi5nYW1le1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIGp1c3RpZnktY29udGVudDogc3BhY2UtYmV0d2VlbjtcclxuICAgIGZsZXgtd3JhcDogd3JhcDtcclxuICAgIGFsaWduLWl0ZW1zOnN0cmV0Y2g7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiBkYXJrZ3JlZW47XHJcbiAgICBjb2xvcjogd2hpdGU7XHJcbiAgICBwYWRkaW5nOiAxMHB4O1xyXG59XHJcblxyXG4ucGxheWVye1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogcmdiKDAsIDQzLCAxNik7XHJcbiAgICBwYWRkaW5nOiA0cHg7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbiAgICAvKiB3aWR0aDogMzIwcHg7ICovXHJcblxyXG59XHJcblxyXG4ucGxheWVyUHJvcHtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IHNwYWNlLWJldHdlZW47XHJcbiAgICBmbGV4LWdyb3c6IGluaGVyaXQ7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbn1cclxuXHJcbi5jYXJke1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogYXp1cmU7IFxyXG4gICAganVzdGlmeS1jb250ZW50OiBzcGFjZS1iZXR3ZWVuO1xyXG4gICAgcGFkZGluZzogNHB4O1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG5cclxufVxyXG5cclxuLmNhcmRQcm9we1xyXG4gICAgY29sb3I6IGJsYWNrO1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG59XHJcblxyXG4uZ2FtZUJ1dHRvbnN7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG59XHJcblxyXG4uYnRTdG9we1xyXG4gICAgbWFyZ2luLWxlZnQ6IDIwcHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/pages/game/game.component.html":
/*!************************************************!*\
  !*** ./src/app/pages/game/game.component.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\nStart game\n<div class=\"selector\">\n  <div class=\"userLine\">\n    Bots Count \n    <select [(ngModel)]=\"startGameModel.countBots\" >\n      <option>1</option>\n      <option>2</option>\n      <option>3</option>\n      <option>4</option>\n      <option>5</option>\n    </select>\n    <button class=\"btn btn-success\" (click)=\"onStart()\">Start</button> \n    <a class=\"btn btn-primary\" routerLink=\"/choose\">Back</a>\n  </div> \n\n\n</div><br/><br/><br/>\n\n<div class=\"game\" *ngIf=\"isStop\">  \n    <div class=\"player\" *ngFor=\"let item of winnerModel\">\n      Name: {{item.name}}\n      Value: {{item.value}}\n    </div>\n</div><br>\n\n\n<div class=\"game\" *ngIf=\"isNewGame\">\n  <div class=\"player\" *ngIf=\"gameModel.user\">\n      <div class=\"playerProp\">Name: {{gameModel.user.name}}</div>\n      <div class=\"playerProp\">\n          <div class=\"card\" *ngFor=\"let card of gameModel.user.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n          </div>\n      </div>\n      <div class=\"playerProp\">\n        <div class=\"\">Score: {{gameModel.user.score}}</div>\n        <div class=\"gameButtons\">\n          <button class=\"btStart\" [disabled]=\"isStop\" (click)=\"onAddCard()\">Add Card</button> \n          <button class=\"btStop\" [disabled]=\"isStop\" (click)=\"onStopGame()\">Stop</button> \n       </div>\n      </div>\n  </div>\n  \n  <div class=\"player\" *ngFor=\"let bot of gameModel.bots\">\n    <div class=\"playerProp\">Name: {{bot.name}}</div>\n    <div class=\"playerProp\">\n        <div class=\"card\" *ngFor=\"let card of bot.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n        </div>\n    </div>\n    <div class=\"playerProp\">Score: {{bot.score}}</div>\n  </div>\n</div>\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<!-- newGame\n<div class=\"game\">\n    <div class=\"player\" *ngIf=\"userPlayer\">\n        <div class=\"playerProp\">Name: {{userPlayer.name}}</div>\n        <div class=\"playerProp\">{{userPlayer.card}}\n            <div class=\"card\" *ngFor=\"let card of userPlayer.cards\">\n                <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n                <div class=\"cardProp\">Suit: {{card.suit}}</div>\n                <div class=\"cardProp\">Value: {{card.value}}</div>\n            </div>\n        </div>\n        <div class=\"playerProp\">Score: {{userPlayer.score}}</div>\n    </div>\n  <div class=\"player\" *ngFor=\"let bot of bots\">\n    <div class=\"playerProp\">Name: {{bot.name}}</div>\n    <div class=\"playerProp\">{{bot.card}}\n        <div class=\"card\" *ngFor=\"let card of bot.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n        </div>\n    </div>\n    <div class=\"playerProp\">Score: {{bot.score}}</div>\n  </div>\n\n  <div class=\"addCard\">\n      <button (click)=\"addCard()\">Add Card</button> \n  </div>\n</div> -->\n"

/***/ }),

/***/ "./src/app/pages/game/game.component.ts":
/*!**********************************************!*\
  !*** ./src/app/pages/game/game.component.ts ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var account_service_1 = __webpack_require__(/*! ../../../shared/services/account.service */ "./src/shared/services/account.service.ts");
var game_service_1 = __webpack_require__(/*! ../../../shared/services/game.service */ "./src/shared/services/game.service.ts");
var responseSignUpAccountView_1 = __webpack_require__(/*! ../../../shared/models/Account/responseSignUpAccountView */ "./src/shared/models/Account/responseSignUpAccountView.ts");
var requestStartGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/requestStartGameView */ "./src/shared/models/Game/requestStartGameView.ts");
var responseStartGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/responseStartGameView */ "./src/shared/models/Game/responseStartGameView.ts");
var requestGetCardGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/requestGetCardGameView */ "./src/shared/models/Game/requestGetCardGameView.ts");
var responseCardGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/responseCardGameView */ "./src/shared/models/Game/responseCardGameView.ts");
var requestStopGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/requestStopGameView */ "./src/shared/models/Game/requestStopGameView.ts");
var responseStopGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/responseStopGameView */ "./src/shared/models/Game/responseStopGameView.ts");
var responseWinnerGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/responseWinnerGameView */ "./src/shared/models/Game/responseWinnerGameView.ts");
var GameComponent = /** @class */ (function () {
    function GameComponent(router, accountService, gameService) {
        this.router = router;
        this.accountService = accountService;
        this.gameService = gameService;
        this.isNewGame = false;
        this.isStop = false;
        this.userModel = new responseSignUpAccountView_1.ResponseSignUpAccountView;
        this.startGameModel = new requestStartGameView_1.RequestStartGameView;
        this.gameModel = new responseStartGameView_1.ResponseStartGameView;
        this.getCardModel = new requestGetCardGameView_1.RequestGetCardGameView;
        this.cardModel = new responseCardGameView_1.ResponseCardGameView;
        this.stopModel = new requestStopGameView_1.RequestStopGameView;
        this.stopGameModel = new responseStopGameView_1.ResponseStopGameView;
        this.winnerModel = new responseWinnerGameView_1.ResponseWinnerGameView;
    }
    GameComponent.prototype.ngOnInit = function () {
        this.getUserData();
    };
    GameComponent.prototype.onStopGame = function () {
        var _this = this;
        this.isStop = true;
        this.stopModel.userId = this.userModel.userId;
        this.stopModel.gameId = this.gameModel.gameId;
        this.gameService.stop(this.stopModel)
            .subscribe(function (response) {
            _this.stopGameModel = response;
            _this.gameModel.bots = _this.stopGameModel.bots;
            _this.gameModel.cardsleft = _this.stopGameModel.cardsleft;
            _this.gameModel.user = _this.stopGameModel.user;
            _this.winnerModel = _this.stopGameModel.winner;
        });
    };
    GameComponent.prototype.onAddCard = function () {
        var _this = this;
        this.getCardModel.gameId = this.gameModel.gameId;
        this.getCardModel.userId = this.userModel.userId;
        this.gameService.getCard(this.getCardModel)
            .subscribe(function (response) {
            _this.cardModel = response;
            _this.gameModel.user.cards.push(_this.cardModel);
            _this.gameModel.user.score += _this.cardModel.value;
            if (_this.gameModel.user.score > 21) {
                _this.onStopGame();
            }
        });
    };
    GameComponent.prototype.onStart = function () {
        var _this = this;
        this.isStop = false;
        this.startGameModel.userId = this.userModel.userId;
        this.gameService.start(this.startGameModel)
            .subscribe(function (response) {
            _this.gameModel = response;
        });
        this.getUserData();
        this.isNewGame = true;
    };
    GameComponent.prototype.getUserData = function () {
        var _this = this;
        var userId = this.accountService.getUserId();
        this.accountService.get(userId)
            .subscribe(function (response) {
            _this.userModel = response;
        });
    };
    GameComponent = __decorate([
        core_1.Component({
            selector: 'app-game',
            template: __webpack_require__(/*! ./game.component.html */ "./src/app/pages/game/game.component.html"),
            styles: [__webpack_require__(/*! ./game.component.css */ "./src/app/pages/game/game.component.css")]
        }),
        __metadata("design:paramtypes", [router_1.Router, account_service_1.AccountService, game_service_1.GameService])
    ], GameComponent);
    return GameComponent;
}());
exports.GameComponent = GameComponent;


/***/ }),

/***/ "./src/app/pages/game/game.module.ts":
/*!*******************************************!*\
  !*** ./src/app/pages/game/game.module.ts ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var common_1 = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
var forms_1 = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
var game_routing_module_1 = __webpack_require__(/*! ./game-routing.module */ "./src/app/pages/game/game-routing.module.ts");
var game_component_1 = __webpack_require__(/*! ./game.component */ "./src/app/pages/game/game.component.ts");
var GameModule = /** @class */ (function () {
    function GameModule() {
    }
    GameModule = __decorate([
        core_1.NgModule({
            declarations: [
                game_component_1.GameComponent
            ],
            imports: [
                common_1.CommonModule,
                game_routing_module_1.GameRoutingModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule
            ]
        })
    ], GameModule);
    return GameModule;
}());
exports.GameModule = GameModule;


/***/ }),

/***/ "./src/shared/models/Game/requestGetCardGameView.ts":
/*!**********************************************************!*\
  !*** ./src/shared/models/Game/requestGetCardGameView.ts ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestGetCardGameView = /** @class */ (function () {
    function RequestGetCardGameView() {
    }
    return RequestGetCardGameView;
}());
exports.RequestGetCardGameView = RequestGetCardGameView;


/***/ }),

/***/ "./src/shared/models/Game/requestStartGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/requestStartGameView.ts ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestStartGameView = /** @class */ (function () {
    function RequestStartGameView() {
    }
    return RequestStartGameView;
}());
exports.RequestStartGameView = RequestStartGameView;


/***/ }),

/***/ "./src/shared/models/Game/requestStopGameView.ts":
/*!*******************************************************!*\
  !*** ./src/shared/models/Game/requestStopGameView.ts ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestStopGameView = /** @class */ (function () {
    function RequestStopGameView() {
    }
    return RequestStopGameView;
}());
exports.RequestStopGameView = RequestStopGameView;


/***/ }),

/***/ "./src/shared/models/Game/responseCardGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/responseCardGameView.ts ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseCardGameView = /** @class */ (function () {
    function ResponseCardGameView() {
    }
    return ResponseCardGameView;
}());
exports.ResponseCardGameView = ResponseCardGameView;


/***/ }),

/***/ "./src/shared/models/Game/responseStartGameView.ts":
/*!*********************************************************!*\
  !*** ./src/shared/models/Game/responseStartGameView.ts ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseStartGameView = /** @class */ (function () {
    function ResponseStartGameView() {
    }
    return ResponseStartGameView;
}());
exports.ResponseStartGameView = ResponseStartGameView;


/***/ }),

/***/ "./src/shared/models/Game/responseStopGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/responseStopGameView.ts ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseStopGameView = /** @class */ (function () {
    function ResponseStopGameView() {
    }
    return ResponseStopGameView;
}());
exports.ResponseStopGameView = ResponseStopGameView;


/***/ }),

/***/ "./src/shared/models/Game/responseWinnerGameView.ts":
/*!**********************************************************!*\
  !*** ./src/shared/models/Game/responseWinnerGameView.ts ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseWinnerGameView = /** @class */ (function () {
    function ResponseWinnerGameView() {
    }
    return ResponseWinnerGameView;
}());
exports.ResponseWinnerGameView = ResponseWinnerGameView;


/***/ }),

/***/ "./src/shared/services/game.service.ts":
/*!*********************************************!*\
  !*** ./src/shared/services/game.service.ts ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var environment_1 = __webpack_require__(/*! ../../environments/environment */ "./src/environments/environment.ts");
var GameService = /** @class */ (function () {
    function GameService(http) {
        this.http = http;
        this.rootUrl = environment_1.environment.apiUrl;
    }
    GameService.prototype.start = function (model) {
        return this.http.post(this.rootUrl + 'Game/StartGame', model);
    };
    GameService.prototype.getCard = function (model) {
        return this.http.post(this.rootUrl + 'Game/GetCard', model);
    };
    GameService.prototype.stop = function (model) {
        return this.http.post(this.rootUrl + 'Game/Stop', model);
    };
    GameService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], GameService);
    return GameService;
}());
exports.GameService = GameService;


/***/ })

}]);
//# sourceMappingURL=pages-game-game-module.js.map