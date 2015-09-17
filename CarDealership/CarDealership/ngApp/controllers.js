var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var DialogController = (function () {
            function DialogController(id, carService) {
                var _this = this;
                this.id = id;
                carService.getCar(id).then(function (result) {
                    _this.car = result.data;
                });
            }
            return DialogController;
        })();
        var HomeController = (function () {
            function HomeController($mdDialog, carService) {
                var _this = this;
                this.$mdDialog = $mdDialog;
                this.carService = carService;
                carService.listCar().then(function (result) {
                    _this.cars = result.data;
                });
            }
            HomeController.prototype.openDialog = function (id) {
                this.$mdDialog.show({
                    controller: DialogController,
                    controllerAs: 'modal',
                    templateUrl: '/ngApp/dialog.html',
                    clickOutsideToClose: true,
                    locals: { id: id }
                });
            };
            HomeController.prototype.searchTitle = function () {
                var _this = this;
                this.carService.filterCars(this.search).then(function (result) {
                    _this.cars = result.data;
                });
            };
            return HomeController;
        })();
        angular.module('MyApp').controller('HomeController', HomeController);
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=controllers.js.map