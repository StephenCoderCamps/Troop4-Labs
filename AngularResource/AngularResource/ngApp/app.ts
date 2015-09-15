namespace AngularResource {

    angular.module('AngularResource', ['ngResource', 'ngRoute'])
        .config(($routeProvider: ng.route.IRouteProvider, $locationProvider:ng.ILocationProvider) => {
        $routeProvider.when('/', {
            templateUrl: '/ngApp/list.html',
            controller: 'MovieListController as vm'
        }).when('/edit/:id', {
            templateUrl: '/ngApp/edit.html',
            controller: 'MovieEditController as vm'
        }).when('/delete/:id', {
            templateUrl: '/ngApp/delete.html',
            controller: 'MovieDeleteController as vm'
        }).when('/add', {
            templateUrl: '/ngApp/add.html',
            controller: 'MovieAddController as vm'
        }).when('/login', {
            templateUrl: '/ngApp/login.html'
        });


            $locationProvider.html5Mode(true);

        });

    angular.module('AngularResource').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
        ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                let token = $window.sessionStorage.getItem('token');
                if (token) {
                    config.headers.Authorization = 'Bearer ' + token;
                }
                return config;
            },
            response: function (response) {
                if (response.status === 401) {
                    $location.path('/login');
                }
                return response || $q.when(response);
            }
        })
        );


    angular.module('AngularResource').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });;




} 