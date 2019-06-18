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

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var responseSignUpAccountView_1 = __webpack_require__(/*! ../models/Account/responseSignUpAccountView */ "./src/shared/models/Account/responseSignUpAccountView.ts");
var i0 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
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
    TransferService.ngInjectableDef = i0.defineInjectable({ factory: function TransferService_Factory() { return new TransferService(); }, token: TransferService, providedIn: "root" });
    return TransferService;
}());
exports.TransferService = TransferService;


/***/ })

}]);
//# sourceMappingURL=common.js.map