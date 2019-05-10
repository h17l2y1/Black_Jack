(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["common"],{

/***/ "./src/shared/models/Account/responseSignUpAccountView.ts":
/*!****************************************************************!*\
  !*** ./src/shared/models/Account/responseSignUpAccountView.ts ***!
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

/***/ "./src/shared/services/transfer.service.ts":
/*!*************************************************!*\
  !*** ./src/shared/services/transfer.service.ts ***!
  \*************************************************/
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
var responseSignUpAccountView_1 = __webpack_require__(/*! ../models/Account/responseSignUpAccountView */ "./src/shared/models/Account/responseSignUpAccountView.ts");
var TransferService = /** @class */ (function () {
    function TransferService() {
        this.userModel = new responseSignUpAccountView_1.ResponseSignUpAccountView;
        this.modelAdded$ = new core_1.EventEmitter();
    }
    TransferService.prototype.getModel = function () {
        return this.userModel;
    };
    TransferService.prototype.setModel = function (model) {
        this.userModel = model;
        this.modelAdded$.emit(model);
    };
    TransferService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [])
    ], TransferService);
    return TransferService;
}());
exports.TransferService = TransferService;


/***/ })

}]);
//# sourceMappingURL=common.js.map