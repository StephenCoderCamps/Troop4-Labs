var AngularResource;
(function (AngularResource) {
    var Controllers;
    (function (Controllers) {
        var MovieListController = (function () {
            function MovieListController(movieService) {
                this.movies = movieService.listMovies();
            }
            return MovieListController;
        })();
        angular.module('AngularResource').controller('MovieListController', MovieListController);
        var MovieEditController = (function () {
            function MovieEditController(movieService, $routeParams, $location) {
                this.movieService = movieService;
                this.$location = $location;
                var id = $routeParams['id'];
                this.movieToEdit = movieService.getMovie(id);
            }
            MovieEditController.prototype.save = function () {
                var _this = this;
                this.movieService.saveMovie(this.movieToEdit).then(function () {
                    _this.$location.path('/');
                });
            };
            return MovieEditController;
        })();
        angular.module('AngularResource').controller('MovieEditController', MovieEditController);
        var MovieDeleteController = (function () {
            function MovieDeleteController(movieService, $routeParams, $location) {
                this.movieService = movieService;
                this.$location = $location;
                var id = $routeParams['id'];
                this.movieToDelete = movieService.getMovie(id);
            }
            MovieDeleteController.prototype.delete = function () {
                var _this = this;
                this.movieService.deleteMovie(this.movieToDelete.id).then(function () {
                    _this.$location.path('/');
                });
            };
            return MovieDeleteController;
        })();
        angular.module('AngularResource').controller('MovieDeleteController', MovieDeleteController);
        var MovieAddController = (function () {
            function MovieAddController(movieService, $location) {
                this.movieService = movieService;
                this.$location = $location;
            }
            MovieAddController.prototype.save = function () {
                var _this = this;
                this.movieService.saveMovie(this.movieToAdd).then(function () {
                    _this.$location.path('/');
                });
            };
            return MovieAddController;
        })();
        angular.module('AngularResource').controller('MovieAddController', MovieAddController);
        var AccountController = (function () {
            function AccountController($http, $window, $location) {
                this.$http = $http;
                this.$window = $window;
                this.$location = $location;
            }
            AccountController.prototype.login = function () {
                var _this = this;
                var data = "grant_type=password&username=" + this.username + "&password=" + this.password;
                this.$http.post('http://MoviesWebAPIApp.azurewebsites.net/Token', data, {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (result) {
                    _this.$window.sessionStorage.setItem('token', result.access_token);
                    _this.$location.path('/');
                }).error(function () {
                    _this.loginMessage = 'Invalid user name/password';
                });
            };
            AccountController.prototype.logout = function () {
                this.$window.sessionStorage.removeItem('token');
            };
            AccountController.prototype.isLoggedIn = function () {
                return this.$window.sessionStorage.getItem('token');
            };
            return AccountController;
        })();
        angular.module('AngularResource').controller('AccountController', AccountController);
    })(Controllers = AngularResource.Controllers || (AngularResource.Controllers = {}));
})(AngularResource || (AngularResource = {}));
//# sourceMappingURL=controllers.js.map