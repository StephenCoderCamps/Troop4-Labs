namespace MyApp.Controllers {

    class DialogController {
        public car
        constructor(private id, carService: MyApp.Services.CarService) {
            carService.getCar(id).then((result) => {
                this.car = result.data;
            });
        }
    }

    class HomeController {
        public cars
        public answer
        public search
        public openDialog(id) {
            this.$mdDialog.show({                controller: DialogController,                controllerAs: 'modal',                templateUrl: '/ngApp/dialog.html',                clickOutsideToClose: true,                locals: {id:id}            })        }

        public searchTitle() {
            this.carService.filterCars(this.search).then((result) => {
                this.cars = result.data;
            });

            
        }

        constructor(private $mdDialog: angular.material.IDialogService, private carService: MyApp.Services.CarService) {
            carService.listCar().then((result) => {
                this.cars = result.data;
            });

        }
    }

    angular.module('MyApp').controller('HomeController', HomeController);
} 