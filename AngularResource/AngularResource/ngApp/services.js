var AngularResource;
(function (AngularResource) {
    var Services;
    (function (Services) {
        var MovieService = (function () {
            function MovieService($resource) {
                this.MovieResource = $resource('http://MoviesWebAPIApp.AzureWebsites.net/api/movies/:id');
            }
            MovieService.prototype.listMovies = function () {
                return this.MovieResource.query();
            };
            MovieService.prototype.getMovie = function (id) {
                return this.MovieResource.get({ id: id });
            };
            MovieService.prototype.saveMovie = function (movie) {
                return this.MovieResource.save(movie).$promise;
            };
            MovieService.prototype.deleteMovie = function (id) {
                return this.MovieResource.delete({ id: id }).$promise;
            };
            return MovieService;
        })();
        Services.MovieService = MovieService;
        angular.module('AngularResource').service('movieService', MovieService);
    })(Services = AngularResource.Services || (AngularResource.Services = {}));
})(AngularResource || (AngularResource = {}));
//# sourceMappingURL=services.js.map