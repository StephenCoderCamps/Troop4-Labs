var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var GenresController = (function () {
            function GenresController($resource) {
                this.GenreResource = new $resource('/api/genres');
                this.genres = this.GenreResource.query();
            }
            return GenresController;
        })();
        angular.module('MyApp').controller('GenresController', GenresController);
        var OneGenreController = (function () {
            function OneGenreController($resource) {
                this.GenreResource = new $resource('/api/genres/:id');
                this.genre = this.GenreResource.get({ id: 3 });
            }
            return OneGenreController;
        })();
        angular.module('MyApp').controller('OneGenreController', OneGenreController);
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=controllers.js.map