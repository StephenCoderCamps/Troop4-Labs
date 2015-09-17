var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var CarService = (function () {
            function CarService($http, WebAPI) {
                this.$http = $http;
                this.WebAPI = WebAPI;
            }
            CarService.prototype.listCar = function () {
                return this.$http.get(this.WebAPI);
            };
            CarService.prototype.getCar = function (id) {
                return this.$http.get(this.WebAPI + '/' + id);
            };
            CarService.prototype.filterCars = function (search) {
                return this.$http.get(this.WebAPI + '/ByTitle/' + search);
            };
            return CarService;
        })();
        Services.CarService = CarService;
        angular.module('MyApp').service('carService', CarService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=services.js.map