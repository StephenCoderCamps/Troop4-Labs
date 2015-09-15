namespace AngularResource.Controllers {

    class MovieListController {
        public movies

        constructor(movieService: AngularResource.Services.MovieService) {
            this.movies = movieService.listMovies();
        }
    }
    angular.module('AngularResource').controller('MovieListController', MovieListController);

    class MovieEditController {
        public movieToEdit

        public save() {
            this.movieService.saveMovie(this.movieToEdit).then(
                () => {
                    this.$location.path('/');
                }
            );
        }

        constructor
        (
            private movieService: AngularResource.Services.MovieService,
            $routeParams: ng.route.IRouteParamsService,
            private $location: ng.ILocationService
        ) {
                let id = $routeParams['id'];
                this.movieToEdit = movieService.getMovie(id);
        }
    }
    angular.module('AngularResource').controller('MovieEditController', MovieEditController);


    class MovieDeleteController {
        public movieToDelete

        public delete() {
            this.movieService.deleteMovie(this.movieToDelete.id).then(
                () => {
                    this.$location.path('/');
                }
            );
        }

        constructor
            (
            private movieService: AngularResource.Services.MovieService,
            $routeParams: ng.route.IRouteParamsService,
            private $location: ng.ILocationService
            ) {
            let id = $routeParams['id'];
            this.movieToDelete = movieService.getMovie(id);
        }
    }
    angular.module('AngularResource').controller('MovieDeleteController', MovieDeleteController);


    class MovieAddController {
        public movieToAdd

        public save() {
            this.movieService.saveMovie(this.movieToAdd).then(
                () => {
                    this.$location.path('/');
                }
             );
        }

        constructor
        (
            private movieService: AngularResource.Services.MovieService,
            private $location: ng.ILocationService
        ) {}
    }

    angular.module('AngularResource').controller('MovieAddController', MovieAddController);

    class AccountController {
        username: string
        password: string
        loginMessage: string

        login() {
            let data = "grant_type=password&username=" + this.username + "&password=" + this.password;
            this.$http.post('http://MoviesWebAPIApp.azurewebsites.net/Token', data,
                {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success((result: any) => {
                    this.$window.sessionStorage.setItem('token', result.access_token);
                    this.$location.path('/');
                }).error(() => {
                    this.loginMessage = 'Invalid user name/password';
                });
        }

        logout() {
            this.$window.sessionStorage.removeItem('token');
        }

        isLoggedIn() {
            return this.$window.sessionStorage.getItem('token');
        }

        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) { }
    }

    angular.module('AngularResource').controller('AccountController', AccountController);



} 