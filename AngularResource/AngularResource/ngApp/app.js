var AngularResource;
(function (AngularResource) {
    angular.module('AngularResource', ['ngResource', 'ngRoute'])
        .config(function ($routeProvider, $locationProvider) {
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
    angular.module('AngularResource').factory('authInterceptor', function ($q, $window, $location) {
        return ({
            request: function (config) {
                config.headers = config.headers || {};
                var token = $window.sessionStorage.getItem('token');
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
        });
    });
    angular.module('AngularResource').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
    ;
})(AngularResource || (AngularResource = {}));
//# sourceMappingURL=app.js.map