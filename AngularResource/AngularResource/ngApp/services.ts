namespace AngularResource.Services {

    export class MovieService {
        private MovieResource


        public listMovies() {
            return this.MovieResource.query();
        }


        public getMovie(id) {
            return this.MovieResource.get({id:id});
        }

        public saveMovie(movie) {
            return this.MovieResource.save(movie).$promise;
        }

        public deleteMovie(id) {
            return this.MovieResource.delete({ id: id }).$promise;
        }


        constructor($resource: ng.resource.IResourceService) {
            this.MovieResource = $resource('http://MoviesWebAPIApp.AzureWebsites.net/api/movies/:id');
        }



    }

    angular.module('AngularResource').service('movieService', MovieService);

} 