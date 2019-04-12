(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/Auth/auth.guard.ts":
/*!************************************!*\
  !*** ./src/app/Auth/auth.guard.ts ***!
  \************************************/
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
var AuthGuard = /** @class */ (function () {
    function AuthGuard(router) {
        this.router = router;
    }
    AuthGuard.prototype.canActivate = function (next, state) {
        if (localStorage.getItem('token') != null)
            return true;
        else {
            this.router.navigate(['login']);
            return false;
        }
    };
    AuthGuard = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [router_1.Router])
    ], AuthGuard);
    return AuthGuard;
}());
exports.AuthGuard = AuthGuard;


/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
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
var login_component_1 = __webpack_require__(/*! ./pages/login/login.component */ "./src/app/pages/login/login.component.ts");
// import { SignUpComponent } from './pages/sign-up/sign-up.component';
var game_component_1 = __webpack_require__(/*! ./pages/game/game.component */ "./src/app/pages/game/game.component.ts");
var auth_guard_1 = __webpack_require__(/*! ./Auth/auth.guard */ "./src/app/Auth/auth.guard.ts");
var statistic_component_1 = __webpack_require__(/*! ./pages/statistic/statistic.component */ "./src/app/pages/statistic/statistic.component.ts");
var routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    //{ path: 'sign-up', component: SignUpComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'game', component: game_component_1.GameComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'statistic', component: statistic_component_1.StatisticComponent },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;


/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\n  <router-outlet></router-outlet>\n</div>"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
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
var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'BlackAngular';
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;


/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
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
var platform_browser_1 = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var forms_1 = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
var app_routing_module_1 = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
var app_component_1 = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
var account_service_1 = __webpack_require__(/*! ../shared/services/account.service */ "./src/shared/services/account.service.ts");
var http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var login_component_1 = __webpack_require__(/*! ./pages/login/login.component */ "./src/app/pages/login/login.component.ts");
var sign_up_component_1 = __webpack_require__(/*! ./pages/sign-up/sign-up.component */ "./src/app/pages/sign-up/sign-up.component.ts");
var game_component_1 = __webpack_require__(/*! ./pages/game/game.component */ "./src/app/pages/game/game.component.ts");
var angular_jwt_1 = __webpack_require__(/*! @auth0/angular-jwt */ "./node_modules/@auth0/angular-jwt/index.js");
var auth_interceptor_1 = __webpack_require__(/*! ./auth/auth.interceptor */ "./src/app/auth/auth.interceptor.ts");
var statistic_component_1 = __webpack_require__(/*! ./pages/statistic/statistic.component */ "./src/app/pages/statistic/statistic.component.ts");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                sign_up_component_1.SignUpComponent,
                login_component_1.LoginComponent,
                game_component_1.GameComponent,
                statistic_component_1.StatisticComponent
            ],
            imports: [
                platform_browser_1.BrowserModule,
                app_routing_module_1.AppRoutingModule,
                forms_1.ReactiveFormsModule,
                http_1.HttpClientModule,
                forms_1.FormsModule,
                angular_jwt_1.JwtModule
            ],
            providers: [account_service_1.AccountService, {
                    provide: http_1.HTTP_INTERCEPTORS,
                    useClass: auth_interceptor_1.AuthInterceptor,
                    multi: true
                }],
            bootstrap: [
                app_component_1.AppComponent
            ]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;


/***/ }),

/***/ "./src/app/auth/auth.interceptor.ts":
/*!******************************************!*\
  !*** ./src/app/auth/auth.interceptor.ts ***!
  \******************************************/
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
var operators_1 = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var AuthInterceptor = /** @class */ (function () {
    function AuthInterceptor(router) {
        this.router = router;
    }
    AuthInterceptor.prototype.intercept = function (req, next) {
        var _this = this;
        if (localStorage.getItem('token') != null) {
            var clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });
            return next.handle(clonedReq).pipe(operators_1.tap(function (succ) { }, function (err) {
                if (err.status == 401) {
                    localStorage.removeItem('token');
                    _this.router.navigateByUrl('login');
                }
            }));
        }
        else
            return next.handle(req.clone());
    };
    AuthInterceptor = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [router_1.Router])
    ], AuthInterceptor);
    return AuthInterceptor;
}());
exports.AuthInterceptor = AuthInterceptor;


/***/ }),

/***/ "./src/app/pages/game/game.component.css":
/*!***********************************************!*\
  !*** ./src/app/pages/game/game.component.css ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".userData{\r\n    background-color: rgb(197, 233, 233);\r\n    padding: 10px;\r\n    width: 320px;\r\n}\r\n.userLine{\r\n    margin: 10px;\r\n}\r\n.selector{\r\n    background-color: rgb(178, 214, 214);\r\n    padding: 10px;\r\n    width: 320px;\r\n}\r\n.option{\r\n    margin: 10px;\r\n}\r\n.game{\r\n    display: flex;\r\n    justify-content: space-between;\r\n    flex-wrap: wrap;\r\n    align-items:stretch;\r\n    background-color: darkgreen;\r\n    color: white;\r\n    padding: 10px;\r\n}\r\n.player{\r\n    background-color: rgb(0, 43, 16);\r\n    padding: 4px;\r\n    margin: 10px;\r\n    /* width: 320px; */\r\n\r\n}\r\n.playerProp{\r\n    display: flex;\r\n    justify-content: space-between;\r\n    flex-grow: inherit;\r\n    margin: 10px;\r\n}\r\n.card{\r\n    background-color: azure; \r\n    justify-content: space-between;\r\n    padding: 4px;\r\n    margin: 10px;\r\n\r\n}\r\n.cardProp{\r\n    color: black;\r\n    margin: 10px;\r\n}\r\n.gameButtons{\r\n    display: flex;\r\n}\r\n.btStop{\r\n    margin-left: 20px;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvZ2FtZS9nYW1lLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxxQ0FBcUM7SUFDckMsY0FBYztJQUNkLGFBQWE7Q0FDaEI7QUFDRDtJQUNJLGFBQWE7Q0FDaEI7QUFFRDtJQUNJLHFDQUFxQztJQUNyQyxjQUFjO0lBQ2QsYUFBYTtDQUNoQjtBQUNEO0lBQ0ksYUFBYTtDQUNoQjtBQUVEO0lBQ0ksY0FBYztJQUNkLCtCQUErQjtJQUMvQixnQkFBZ0I7SUFDaEIsb0JBQW9CO0lBQ3BCLDRCQUE0QjtJQUM1QixhQUFhO0lBQ2IsY0FBYztDQUNqQjtBQUVEO0lBQ0ksaUNBQWlDO0lBQ2pDLGFBQWE7SUFDYixhQUFhO0lBQ2IsbUJBQW1COztDQUV0QjtBQUVEO0lBQ0ksY0FBYztJQUNkLCtCQUErQjtJQUMvQixtQkFBbUI7SUFDbkIsYUFBYTtDQUNoQjtBQUVEO0lBQ0ksd0JBQXdCO0lBQ3hCLCtCQUErQjtJQUMvQixhQUFhO0lBQ2IsYUFBYTs7Q0FFaEI7QUFFRDtJQUNJLGFBQWE7SUFDYixhQUFhO0NBQ2hCO0FBRUQ7SUFDSSxjQUFjO0NBQ2pCO0FBRUQ7SUFDSSxrQkFBa0I7Q0FDckIiLCJmaWxlIjoic3JjL2FwcC9wYWdlcy9nYW1lL2dhbWUuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi51c2VyRGF0YXtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IHJnYigxOTcsIDIzMywgMjMzKTtcclxuICAgIHBhZGRpbmc6IDEwcHg7XHJcbiAgICB3aWR0aDogMzIwcHg7XHJcbn1cclxuLnVzZXJMaW5le1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG59XHJcblxyXG4uc2VsZWN0b3J7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiByZ2IoMTc4LCAyMTQsIDIxNCk7XHJcbiAgICBwYWRkaW5nOiAxMHB4O1xyXG4gICAgd2lkdGg6IDMyMHB4O1xyXG59XHJcbi5vcHRpb257XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbn1cclxuXHJcbi5nYW1le1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIGp1c3RpZnktY29udGVudDogc3BhY2UtYmV0d2VlbjtcclxuICAgIGZsZXgtd3JhcDogd3JhcDtcclxuICAgIGFsaWduLWl0ZW1zOnN0cmV0Y2g7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiBkYXJrZ3JlZW47XHJcbiAgICBjb2xvcjogd2hpdGU7XHJcbiAgICBwYWRkaW5nOiAxMHB4O1xyXG59XHJcblxyXG4ucGxheWVye1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogcmdiKDAsIDQzLCAxNik7XHJcbiAgICBwYWRkaW5nOiA0cHg7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbiAgICAvKiB3aWR0aDogMzIwcHg7ICovXHJcblxyXG59XHJcblxyXG4ucGxheWVyUHJvcHtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IHNwYWNlLWJldHdlZW47XHJcbiAgICBmbGV4LWdyb3c6IGluaGVyaXQ7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbn1cclxuXHJcbi5jYXJke1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogYXp1cmU7IFxyXG4gICAganVzdGlmeS1jb250ZW50OiBzcGFjZS1iZXR3ZWVuO1xyXG4gICAgcGFkZGluZzogNHB4O1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG5cclxufVxyXG5cclxuLmNhcmRQcm9we1xyXG4gICAgY29sb3I6IGJsYWNrO1xyXG4gICAgbWFyZ2luOiAxMHB4O1xyXG59XHJcblxyXG4uZ2FtZUJ1dHRvbnN7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG59XHJcblxyXG4uYnRTdG9we1xyXG4gICAgbWFyZ2luLWxlZnQ6IDIwcHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/pages/game/game.component.html":
/*!************************************************!*\
  !*** ./src/app/pages/game/game.component.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n<div class=\"userData\" *ngIf=\"userModel\"> User Data \n  <div class=\"userLine\"> Id: {{userModel.userId}} </div>\n  <div class=\"userLine\"> Login: {{userModel.userName}}</div>\n  <div class=\"userLine\"> Points: {{userModel.points}}</div>\n  <div class=\"userLine\"> Role: {{userModel.role}}</div>\n  <button (click)=\"onLogout()\">Logout</button>\n  <button class=\"btStop\" (click)=\"onStatistic()\">Statistic</button>\n</div><br/><br/><br/>\n\nStart game\n<div class=\"selector\">\n  <div class=\"userLine\">\n    Bots Count \n    <select [(ngModel)]=\"startGameModel.countBots\" >\n      <option>1</option>\n      <option>2</option>\n      <option>3</option>\n      <option>4</option>\n      <option>5</option>\n    </select>\n  </div> \n  <button (click)=\"onStart()\">Start</button> \n</div><br/><br/><br/>\n\n<div class=\"game\" *ngIf=\"stop\">  \n    <div class=\"player\" *ngFor=\"let item of winnerModel\">\n      Name: {{item.name}}\n      Value: {{item.value}}\n    </div>\n</div><br>\n\n\n<div class=\"game\" *ngIf=\"isNewGame\">\n  <div class=\"player\" *ngIf=\"gameModel.user\">\n      <div class=\"playerProp\">Name: {{gameModel.user.name}}</div>\n      <div class=\"playerProp\">\n          <div class=\"card\" *ngFor=\"let card of gameModel.user.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n          </div>\n      </div>\n      <div class=\"playerProp\">\n        <div class=\"\">Score: {{gameModel.user.score}}</div>\n        <div class=\"gameButtons\">\n          <button class=\"btStart\" (click)=\"onAddCard()\">Add Card</button> \n          <button class=\"btStop\" (click)=\"onStopGame()\">Stop</button> \n       </div>\n      </div>\n  </div>\n  \n  <div class=\"player\" *ngFor=\"let bot of gameModel.bots\">\n    <div class=\"playerProp\">Name: {{bot.name}}</div>\n    <div class=\"playerProp\">\n        <div class=\"card\" *ngFor=\"let card of bot.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n        </div>\n    </div>\n    <div class=\"playerProp\">Score: {{bot.score}}</div>\n  </div>\n</div>\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<!-- newGame\n<div class=\"game\">\n    <div class=\"player\" *ngIf=\"userPlayer\">\n        <div class=\"playerProp\">Name: {{userPlayer.name}}</div>\n        <div class=\"playerProp\">{{userPlayer.card}}\n            <div class=\"card\" *ngFor=\"let card of userPlayer.cards\">\n                <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n                <div class=\"cardProp\">Suit: {{card.suit}}</div>\n                <div class=\"cardProp\">Value: {{card.value}}</div>\n            </div>\n        </div>\n        <div class=\"playerProp\">Score: {{userPlayer.score}}</div>\n    </div>\n  <div class=\"player\" *ngFor=\"let bot of bots\">\n    <div class=\"playerProp\">Name: {{bot.name}}</div>\n    <div class=\"playerProp\">{{bot.card}}\n        <div class=\"card\" *ngFor=\"let card of bot.cards\">\n            <div class=\"cardProp\">Rank: {{card.ranks}}</div>\n            <div class=\"cardProp\">Suit: {{card.suit}}</div>\n            <div class=\"cardProp\">Value: {{card.value}}</div>\n        </div>\n    </div>\n    <div class=\"playerProp\">Score: {{bot.score}}</div>\n  </div>\n\n  <div class=\"addCard\">\n      <button (click)=\"addCard()\">Add Card</button> \n  </div>\n</div> -->\n"

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
var jwt_decode = __webpack_require__(/*! jwt-decode */ "./node_modules/jwt-decode/lib/index.js");
var account_service_1 = __webpack_require__(/*! ../../../shared/services/account.service */ "./src/shared/services/account.service.ts");
var game_service_1 = __webpack_require__(/*! ../../../shared/services/game.service */ "./src/shared/services/game.service.ts");
var ResponseSignUpAccountView_1 = __webpack_require__(/*! ../../../shared/models/Account/ResponseSignUpAccountView */ "./src/shared/models/Account/ResponseSignUpAccountView.ts");
var RequestStartGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/RequestStartGameView */ "./src/shared/models/Game/RequestStartGameView.ts");
var ResponseStartGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/ResponseStartGameView */ "./src/shared/models/Game/ResponseStartGameView.ts");
var RequestGetCardGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/RequestGetCardGameView */ "./src/shared/models/Game/RequestGetCardGameView.ts");
var ResponseCardGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/ResponseCardGameView */ "./src/shared/models/Game/ResponseCardGameView.ts");
var RequestStopGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/RequestStopGameView */ "./src/shared/models/Game/RequestStopGameView.ts");
var ResponseStopGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/ResponseStopGameView */ "./src/shared/models/Game/ResponseStopGameView.ts");
var ResponseWinnerGameView_1 = __webpack_require__(/*! ../../../shared/models/Game/ResponseWinnerGameView */ "./src/shared/models/Game/ResponseWinnerGameView.ts");
var GameComponent = /** @class */ (function () {
    function GameComponent(router, accountService, gameService) {
        this.router = router;
        this.accountService = accountService;
        this.gameService = gameService;
        this.isNewGame = false;
        this.stop = false;
        this.userModel = new ResponseSignUpAccountView_1.ResponseSignUpAccountView;
        this.startGameModel = new RequestStartGameView_1.RequestStartGameView;
        this.gameModel = new ResponseStartGameView_1.ResponseStartGameView;
        this.getCardModel = new RequestGetCardGameView_1.RequestGetCardGameView;
        this.cardModel = new ResponseCardGameView_1.ResponseCardGameView;
        this.stopModel = new RequestStopGameView_1.RequestStopGameView;
        this.stopGameModel = new ResponseStopGameView_1.ResponseStopGameView;
        this.winnerModel = new ResponseWinnerGameView_1.ResponseWinnerGameView;
    }
    GameComponent.prototype.ngOnInit = function () {
        this.getUserData();
    };
    GameComponent.prototype.onStatistic = function () {
        this.router.navigateByUrl('statistic');
    };
    GameComponent.prototype.onStopGame = function () {
        var _this = this;
        this.stop = true;
        this.stopModel.userId = this.userModel.userId;
        this.stopModel.gameId = this.gameModel.gameId;
        this.gameService.stop(this.stopModel)
            .subscribe(function (response) {
            _this.stopGameModel = response;
            _this.gameModel.bots = _this.stopGameModel.bots;
            _this.gameModel.cardsleft = _this.stopGameModel.cardsleft;
            _this.gameModel.user = _this.stopGameModel.user;
            _this.winnerModel = _this.stopGameModel.winner;
            console.log(_this.stopGameModel);
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
        });
    };
    GameComponent.prototype.onStart = function () {
        var _this = this;
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
        var userId = this.getUserId();
        this.accountService.get(userId)
            .subscribe(function (response) {
            _this.userModel = response;
        });
    };
    GameComponent.prototype.getUserId = function () {
        var token = localStorage.getItem('token');
        var tokenClaims = jwt_decode(token, "");
        return tokenClaims.UserId;
    };
    GameComponent.prototype.onLogout = function () {
        localStorage.removeItem('token');
        this.router.navigate(['login']);
    };
    GameComponent = __decorate([
        core_1.Component({
            selector: 'app-game',
            template: __webpack_require__(/*! ./game.component.html */ "./src/app/pages/game/game.component.html"),
            styles: [__webpack_require__(/*! ./game.component.css */ "./src/app/pages/game/game.component.css")]
        }),
        __metadata("design:paramtypes", [router_1.Router, account_service_1.AccountService,
            game_service_1.GameService])
    ], GameComponent);
    return GameComponent;
}());
exports.GameComponent = GameComponent;


/***/ }),

/***/ "./src/app/pages/login/login.component.css":
/*!*************************************************!*\
  !*** ./src/app/pages/login/login.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL2xvZ2luL2xvZ2luLmNvbXBvbmVudC5jc3MifQ== */"

/***/ }),

/***/ "./src/app/pages/login/login.component.html":
/*!**************************************************!*\
  !*** ./src/app/pages/login/login.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<br><br><br>\n<div class=\"login\">\n  <input [(ngModel)]=\"signUpmodel.userName\"> UserName <br> \n  <button (click)=\"onLogin()\">Login</button>\n</div>\n\n"

/***/ }),

/***/ "./src/app/pages/login/login.component.ts":
/*!************************************************!*\
  !*** ./src/app/pages/login/login.component.ts ***!
  \************************************************/
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
var forms_1 = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
var account_service_1 = __webpack_require__(/*! ../../../shared/services/account.service */ "./src/shared/services/account.service.ts");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var RequestSignUpAccountView_1 = __webpack_require__(/*! ../../../shared/models/Account/RequestSignUpAccountView */ "./src/shared/models/Account/RequestSignUpAccountView.ts");
var LoginComponent = /** @class */ (function () {
    function LoginComponent(service, router) {
        this.service = service;
        this.router = router;
        this.signUpmodel = new RequestSignUpAccountView_1.RequestSignUpAccountView;
    }
    LoginComponent.prototype.ngOnInit = function () {
        if (localStorage.getItem('token') != null) {
            //this.router.navigateByUrl('game')
        }
        this.signUpControl = new forms_1.FormGroup({
            UserName: new forms_1.FormControl()
        });
    };
    LoginComponent.prototype.onLogin = function () {
        var _this = this;
        this.service.login(this.signUpmodel).subscribe(function (res) {
            localStorage.setItem('token', res.token);
            _this.router.navigateByUrl('game');
        });
    };
    LoginComponent.prototype.onSignUp = function () {
        this.service.signUp(this.signUpmodel).subscribe();
        this.router.navigateByUrl('game');
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'app-login',
            template: __webpack_require__(/*! ./login.component.html */ "./src/app/pages/login/login.component.html"),
            styles: [__webpack_require__(/*! ./login.component.css */ "./src/app/pages/login/login.component.css")]
        }),
        __metadata("design:paramtypes", [account_service_1.AccountService, router_1.Router])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;


/***/ }),

/***/ "./src/app/pages/sign-up/sign-up.component.css":
/*!*****************************************************!*\
  !*** ./src/app/pages/sign-up/sign-up.component.css ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3NpZ24tdXAvc2lnbi11cC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/pages/sign-up/sign-up.component.html":
/*!******************************************************!*\
  !*** ./src/app/pages/sign-up/sign-up.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n<!-- <form #userRegistrationForm=\"ngForm\" (ngSubmit)=\"OnSubmit(userRegistrationForm)\">\n  <label>User Name</label><br><br>\n  <input type=\"text\" name=\"UserName\" #UserName=\"ngModel\" [(ngModel)]=\"user.UserName\"><br><br>\n  <button type=\"submit\">Submit</button>\n</form> -->\n\n"

/***/ }),

/***/ "./src/app/pages/sign-up/sign-up.component.ts":
/*!****************************************************!*\
  !*** ./src/app/pages/sign-up/sign-up.component.ts ***!
  \****************************************************/
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
var account_service_1 = __webpack_require__(/*! ../../../shared/services/account.service */ "./src/shared/services/account.service.ts");
var RequestSignUpAccountView_1 = __webpack_require__(/*! ../../../shared/models/Account/RequestSignUpAccountView */ "./src/shared/models/Account/RequestSignUpAccountView.ts");
var SignUpComponent = /** @class */ (function () {
    function SignUpComponent(service) {
        this.service = service;
        this.signUpmodel = new RequestSignUpAccountView_1.RequestSignUpAccountView;
    }
    SignUpComponent.prototype.ngOnInit = function () {
        this.resetForm();
    };
    SignUpComponent.prototype.resetForm = function (form) {
        if (form != null)
            form.reset();
        // this.signUpmodel = {
        //   userName: ''
        // }
    };
    SignUpComponent.prototype.onSubmit = function (form) {
        var _this = this;
        this.service.signUp(form.value)
            .subscribe(function (data) {
            _this.resetForm();
        });
    };
    SignUpComponent = __decorate([
        core_1.Component({
            selector: 'app-sign-up',
            template: __webpack_require__(/*! ./sign-up.component.html */ "./src/app/pages/sign-up/sign-up.component.html"),
            styles: [__webpack_require__(/*! ./sign-up.component.css */ "./src/app/pages/sign-up/sign-up.component.css")]
        }),
        __metadata("design:paramtypes", [account_service_1.AccountService])
    ], SignUpComponent);
    return SignUpComponent;
}());
exports.SignUpComponent = SignUpComponent;


/***/ }),

/***/ "./src/app/pages/statistic/statistic.component.css":
/*!*********************************************************!*\
  !*** ./src/app/pages/statistic/statistic.component.css ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".games{\r\n    padding: 5px;\r\n    margin: 10px;\r\n    background-color: burlywood;\r\n    width: 300px;\r\n}\r\n\r\n.players{\r\n    background-color: darkgray;\r\n}\r\n\r\n.gamesStat{\r\n    background-color: bisque;\r\n}\r\n\r\n.gameProp{\r\n    background-color: cornsilk;\r\n    margin: 5px;\r\n}\r\n\r\n.playerProp{\r\n    display: flex;\r\n    padding: 5px;\r\n    background-color: coral\r\n}\r\n\r\n.cards{\r\n    display: flex;\r\n}\r\n\r\n.card{\r\n    display: flex;\r\n    color: white;\r\n    background-color: rgb(70, 109, 109);\r\n    margin: 10px;\r\n    padding: 10px;\r\n}\r\n\r\n.cardProp{\r\n    margin: 5px;\r\n}\r\n\r\n#pl{\r\n    display: flex;\r\n    flex-wrap: wrap;\r\n    margin: 5px;\r\n}\r\n\r\n.bot{\r\n    padding: 10px;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvcGFnZXMvc3RhdGlzdGljL3N0YXRpc3RpYy5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0ksYUFBYTtJQUNiLGFBQWE7SUFDYiw0QkFBNEI7SUFDNUIsYUFBYTtDQUNoQjs7QUFFRDtJQUNJLDJCQUEyQjtDQUM5Qjs7QUFFRDtJQUNJLHlCQUF5QjtDQUM1Qjs7QUFFRDtJQUNJLDJCQUEyQjtJQUMzQixZQUFZO0NBQ2Y7O0FBRUQ7SUFDSSxjQUFjO0lBQ2QsYUFBYTtJQUNiLHVCQUF1QjtDQUMxQjs7QUFFRDtJQUNJLGNBQWM7Q0FDakI7O0FBRUQ7SUFDSSxjQUFjO0lBQ2QsYUFBYTtJQUNiLG9DQUFvQztJQUNwQyxhQUFhO0lBQ2IsY0FBYztDQUNqQjs7QUFFRDtJQUNJLFlBQVk7Q0FDZjs7QUFFRDtJQUNJLGNBQWM7SUFDZCxnQkFBZ0I7SUFDaEIsWUFBWTtDQUNmOztBQUVEO0lBQ0ksY0FBYztDQUNqQiIsImZpbGUiOiJzcmMvYXBwL3BhZ2VzL3N0YXRpc3RpYy9zdGF0aXN0aWMuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5nYW1lc3tcclxuICAgIHBhZGRpbmc6IDVweDtcclxuICAgIG1hcmdpbjogMTBweDtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IGJ1cmx5d29vZDtcclxuICAgIHdpZHRoOiAzMDBweDtcclxufVxyXG5cclxuLnBsYXllcnN7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiBkYXJrZ3JheTtcclxufVxyXG5cclxuLmdhbWVzU3RhdHtcclxuICAgIGJhY2tncm91bmQtY29sb3I6IGJpc3F1ZTtcclxufVxyXG5cclxuLmdhbWVQcm9we1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogY29ybnNpbGs7XHJcbiAgICBtYXJnaW46IDVweDtcclxufVxyXG5cclxuLnBsYXllclByb3B7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgcGFkZGluZzogNXB4O1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogY29yYWxcclxufVxyXG5cclxuLmNhcmRze1xyXG4gICAgZGlzcGxheTogZmxleDtcclxufVxyXG5cclxuLmNhcmR7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgY29sb3I6IHdoaXRlO1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogcmdiKDcwLCAxMDksIDEwOSk7XHJcbiAgICBtYXJnaW46IDEwcHg7XHJcbiAgICBwYWRkaW5nOiAxMHB4O1xyXG59XHJcblxyXG4uY2FyZFByb3B7XHJcbiAgICBtYXJnaW46IDVweDtcclxufVxyXG5cclxuI3Bse1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIGZsZXgtd3JhcDogd3JhcDtcclxuICAgIG1hcmdpbjogNXB4O1xyXG59XHJcblxyXG4uYm90e1xyXG4gICAgcGFkZGluZzogMTBweDtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/pages/statistic/statistic.component.html":
/*!**********************************************************!*\
  !*** ./src/app/pages/statistic/statistic.component.html ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\n  statistic works!\n</p>\n\n<button (click)=\"onBack()\">Back to Game</button>\n<br><br><br>\n\n\n<div class=\"gameStat\" *ngIf=\"isGame\">\n  <div class=\"gameProp\">GameId: {{gameRes.gameId}}</div>\n  <div class=\"gameProp\">Cardleft: {{gameRes.cardsleft}}</div>\n  <div class=\"gameProp\" id=\"pl\"> User\n    <div class=\"playerProp\">Name: {{gameRes.user.name}}</div>\n    <div class=\"playerProp\">Score: {{gameRes.user.score}}</div>\n      <div class=\"playerProp\">\n        <div class=\"cards\"  *ngFor=\"let card of gameRes.user.cards\">\n            <div class=\"card\">\n                <div class=\"cardProp\">{{card.ranks}}</div>\n                <div class=\"cardProp\">{{card.suit}}</div>\n                <div class=\"cardProp\">{{card.value}}</div>\n            </div>\n        </div>\n      </div><br>\n    <div class=\"gameProp\" id=\"pl\"> Bots\n      <div class=\"bot\" *ngFor=\"let bot of gameRes.bots\">\n          <div class=\"playerProp\">Name: {{bot.name}}</div>\n          <div class=\"playerProp\">Score: {{bot.score}}</div>\n          <div class=\"playerProp\">\n            <div class=\"cards\" *ngFor=\"let card of bot.cards\">\n                <div class=\"card\">\n                    <div class=\"cardProp\">{{card.ranks}}</div>\n                    <div class=\"cardProp\">{{card.suit}}</div>\n                    <div class=\"cardProp\">{{card.value}}</div>\n                </div>\n            </div>\n          </div><br>\n      </div>\n    </div>\n\n  </div>\n\n\n\n  <div class=\"gameProp\" *ngFor=\"let item of gameRes.winner\">\n    Winner: {{item.name}}\n  </div>\n</div>\n\n\n  <div (click)=\"onAllGames()\">All Games</div>\n\n<ol>\n  <!-- <li *ngFor=\"let game of allGamesRes.gameList\"> -->\n    <li *ngFor=\"let game of allGamesRes.gameList\">\n    <div class=\"games\" (click)=\"onGame(game.gameId)\">\n        <p >{{game.gameId}}</p>\n    </div>\n  </li>\n</ol>\n\n\n"

/***/ }),

/***/ "./src/app/pages/statistic/statistic.component.ts":
/*!********************************************************!*\
  !*** ./src/app/pages/statistic/statistic.component.ts ***!
  \********************************************************/
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
var statistic_service_1 = __webpack_require__(/*! ../../../shared/services/statistic.service */ "./src/shared/services/statistic.service.ts");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var jwt_decode = __webpack_require__(/*! jwt-decode */ "./node_modules/jwt-decode/lib/index.js");
var RequestGetAllGamesStatisticView_1 = __webpack_require__(/*! ../../../shared/models/Statistic/RequestGetAllGamesStatisticView */ "./src/shared/models/Statistic/RequestGetAllGamesStatisticView.ts");
var ResponseGetAllGamesStatisticView_1 = __webpack_require__(/*! ../../../shared/models/Statistic/ResponseGetAllGamesStatisticView */ "./src/shared/models/Statistic/ResponseGetAllGamesStatisticView.ts");
var ResponseGetGameStatisticView_1 = __webpack_require__(/*! ../../../shared/models/Statistic/ResponseGetGameStatisticView */ "./src/shared/models/Statistic/ResponseGetGameStatisticView.ts");
var RequestGetGameStatisticView_1 = __webpack_require__(/*! ../../../shared/models/Statistic/RequestGetGameStatisticView */ "./src/shared/models/Statistic/RequestGetGameStatisticView.ts");
var StatisticComponent = /** @class */ (function () {
    function StatisticComponent(router, service) {
        this.router = router;
        this.service = service;
        this.allGamesReq = new RequestGetAllGamesStatisticView_1.RequestGetAllGamesStatisticView;
        this.allGamesRes = new ResponseGetAllGamesStatisticView_1.ResponseGetAllGamesStatisticView;
        this.gameReq = new RequestGetGameStatisticView_1.RequestGetGameStatisticView;
        this.gameRes = new ResponseGetGameStatisticView_1.ResponseGetGameStatisticView;
        this.userId = null;
        this.gameId = null;
        this.isGame = false;
    }
    StatisticComponent.prototype.ngOnInit = function () {
        this.getUserId();
    };
    StatisticComponent.prototype.onGame = function (gameId) {
        var _this = this;
        this.isGame = true;
        this.gameReq.gameId = gameId;
        this.gameReq.playerId = this.userId;
        this.service.getGame(this.gameReq)
            .subscribe(function (response) {
            _this.gameRes = response;
            console.log(_this.gameRes);
        });
    };
    StatisticComponent.prototype.onAllGames = function () {
        var _this = this;
        this.allGamesReq.playerId = this.userId;
        this.service.getAllGames(this.allGamesReq)
            .subscribe(function (response) {
            _this.allGamesRes = response;
            console.log(_this.allGamesRes);
        });
        debugger;
    };
    StatisticComponent.prototype.getUserId = function () {
        var token = localStorage.getItem('token');
        var tokenClaims = jwt_decode(token, "");
        this.userId = tokenClaims.UserId;
    };
    StatisticComponent.prototype.onBack = function () {
        this.router.navigateByUrl('game');
    };
    StatisticComponent = __decorate([
        core_1.Component({
            selector: 'app-statistic',
            template: __webpack_require__(/*! ./statistic.component.html */ "./src/app/pages/statistic/statistic.component.html"),
            styles: [__webpack_require__(/*! ./statistic.component.css */ "./src/app/pages/statistic/statistic.component.css")]
        }),
        __metadata("design:paramtypes", [router_1.Router, statistic_service_1.StatisticService])
    ], StatisticComponent);
    return StatisticComponent;
}());
exports.StatisticComponent = StatisticComponent;


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var platform_browser_dynamic_1 = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
var app_module_1 = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
var environment_1 = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ "./src/shared/models/Account/RequestSignUpAccountView.ts":
/*!***************************************************************!*\
  !*** ./src/shared/models/Account/RequestSignUpAccountView.ts ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestSignUpAccountView = /** @class */ (function () {
    function RequestSignUpAccountView() {
    }
    return RequestSignUpAccountView;
}());
exports.RequestSignUpAccountView = RequestSignUpAccountView;


/***/ }),

/***/ "./src/shared/models/Account/ResponseSignUpAccountView.ts":
/*!****************************************************************!*\
  !*** ./src/shared/models/Account/ResponseSignUpAccountView.ts ***!
  \****************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseSignUpAccountView = /** @class */ (function () {
    function ResponseSignUpAccountView() {
    }
    return ResponseSignUpAccountView;
}());
exports.ResponseSignUpAccountView = ResponseSignUpAccountView;


/***/ }),

/***/ "./src/shared/models/Game/RequestGetCardGameView.ts":
/*!**********************************************************!*\
  !*** ./src/shared/models/Game/RequestGetCardGameView.ts ***!
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

/***/ "./src/shared/models/Game/RequestStartGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/RequestStartGameView.ts ***!
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

/***/ "./src/shared/models/Game/RequestStopGameView.ts":
/*!*******************************************************!*\
  !*** ./src/shared/models/Game/RequestStopGameView.ts ***!
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

/***/ "./src/shared/models/Game/ResponseCardGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/ResponseCardGameView.ts ***!
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

/***/ "./src/shared/models/Game/ResponseStartGameView.ts":
/*!*********************************************************!*\
  !*** ./src/shared/models/Game/ResponseStartGameView.ts ***!
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

/***/ "./src/shared/models/Game/ResponseStopGameView.ts":
/*!********************************************************!*\
  !*** ./src/shared/models/Game/ResponseStopGameView.ts ***!
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

/***/ "./src/shared/models/Game/ResponseWinnerGameView.ts":
/*!**********************************************************!*\
  !*** ./src/shared/models/Game/ResponseWinnerGameView.ts ***!
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

/***/ "./src/shared/models/Statistic/RequestGetAllGamesStatisticView.ts":
/*!************************************************************************!*\
  !*** ./src/shared/models/Statistic/RequestGetAllGamesStatisticView.ts ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestGetAllGamesStatisticView = /** @class */ (function () {
    function RequestGetAllGamesStatisticView() {
    }
    return RequestGetAllGamesStatisticView;
}());
exports.RequestGetAllGamesStatisticView = RequestGetAllGamesStatisticView;


/***/ }),

/***/ "./src/shared/models/Statistic/RequestGetGameStatisticView.ts":
/*!********************************************************************!*\
  !*** ./src/shared/models/Statistic/RequestGetGameStatisticView.ts ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var RequestGetGameStatisticView = /** @class */ (function () {
    function RequestGetGameStatisticView() {
    }
    return RequestGetGameStatisticView;
}());
exports.RequestGetGameStatisticView = RequestGetGameStatisticView;


/***/ }),

/***/ "./src/shared/models/Statistic/ResponseGetAllGamesStatisticView.ts":
/*!*************************************************************************!*\
  !*** ./src/shared/models/Statistic/ResponseGetAllGamesStatisticView.ts ***!
  \*************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseGetAllGamesStatisticView = /** @class */ (function () {
    function ResponseGetAllGamesStatisticView() {
    }
    return ResponseGetAllGamesStatisticView;
}());
exports.ResponseGetAllGamesStatisticView = ResponseGetAllGamesStatisticView;


/***/ }),

/***/ "./src/shared/models/Statistic/ResponseGetGameStatisticView.ts":
/*!*********************************************************************!*\
  !*** ./src/shared/models/Statistic/ResponseGetGameStatisticView.ts ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var ResponseGetGameStatisticView = /** @class */ (function () {
    function ResponseGetGameStatisticView() {
    }
    return ResponseGetGameStatisticView;
}());
exports.ResponseGetGameStatisticView = ResponseGetGameStatisticView;


/***/ }),

/***/ "./src/shared/services/account.service.ts":
/*!************************************************!*\
  !*** ./src/shared/services/account.service.ts ***!
  \************************************************/
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
var AccountService = /** @class */ (function () {
    function AccountService(http) {
        this.http = http;
        this.rootUrl = "http://localhost:52077/";
    }
    AccountService.prototype.signUp = function (user) {
        return this.http.post(this.rootUrl + 'api/Account/SignUp', user);
    };
    AccountService.prototype.login = function (user) {
        return this.http.post(this.rootUrl + 'api/Account/Login', user);
    };
    AccountService.prototype.get = function (userId) {
        return this.http.get(this.rootUrl + 'api/Account/GetById/' + userId);
    };
    AccountService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], AccountService);
    return AccountService;
}());
exports.AccountService = AccountService;


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
var GameService = /** @class */ (function () {
    function GameService(http) {
        this.http = http;
        this.rootUrl = "http://localhost:52077/";
    }
    GameService.prototype.start = function (model) {
        return this.http.post(this.rootUrl + 'api/Game/StartGame', model);
    };
    GameService.prototype.getCard = function (model) {
        return this.http.post(this.rootUrl + 'api/Game/GetCard', model);
    };
    GameService.prototype.stop = function (model) {
        return this.http.post(this.rootUrl + 'api/Game/Stop', model);
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


/***/ }),

/***/ "./src/shared/services/statistic.service.ts":
/*!**************************************************!*\
  !*** ./src/shared/services/statistic.service.ts ***!
  \**************************************************/
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
var StatisticService = /** @class */ (function () {
    function StatisticService(http) {
        this.http = http;
        this.rootUrl = "http://localhost:52077/";
    }
    StatisticService.prototype.getAllGames = function (model) {
        return this.http.post(this.rootUrl + 'api/Statistic/GetAllGames', model);
    };
    StatisticService.prototype.getGame = function (model) {
        return this.http.post(this.rootUrl + 'api/Statistic/GetGame', model);
    };
    StatisticService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], StatisticService);
    return StatisticService;
}());
exports.StatisticService = StatisticService;


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Vlad\Black\BlackJack\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map