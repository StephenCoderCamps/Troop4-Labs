namespace MyApp.Controllers {

    class GenresController {
        private GenreResource

        public genres

        constructor($resource) {
            this.GenreResource = new $resource('/api/genres');
            this.genres = this.GenreResource.query();
        }
    }


    angular.module('MyApp').controller('GenresController', GenresController);





    class OneGenreController {
        private GenreResource

        public genre

        constructor($resource) {
            this.GenreResource = new $resource('/api/genres/:id');
            this.genre = this.GenreResource.get({ id: 3 });
        }
    }


    angular.module('MyApp').controller('OneGenreController', OneGenreController);


} 