namespace MyApp.Services {

    export class CarService {

        public listCar() {
            return this.$http.get(this.WebAPI);
        }
        
        public getCar(id) {
            return this.$http.get(this.WebAPI + '/' + id);
        }

        public filterCars(search) {
            return this.$http.get(this.WebAPI + '/ByTitle/'+search);
        }

        constructor(private $http: ng.IHttpService, private WebAPI) {} 
    }
    angular.module('MyApp').service('carService', CarService);
} 