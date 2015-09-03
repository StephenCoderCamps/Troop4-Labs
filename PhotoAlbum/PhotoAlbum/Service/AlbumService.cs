using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbum.Service
{
    public class AlbumService : PhotoAlbum.Service.IAlbumService
    {
        private IGenericRepository _repo;
        public AlbumService(IGenericRepository repo)
        {
            _repo = repo;

        }
        public IList<Album> ListAlbums()
        { 
            return _repo.Query<Album>().ToList();
        }
        public Album FindAlbum(int id)
        {
            // use .Include() to get associated entities
            return _repo.Query<Album>().Include(m => m.Photos).Where(m => m.Id==id).First();
        }
        public void CreateAlbum(Album album)
        {
            _repo.Add<Album>(album);
            _repo.SaveChanges();
        }
        public void EditAlbum(Album album)
        {
            var original = this.FindAlbum(album.Id);
            original.AlbumName = album.AlbumName;
            _repo.SaveChanges();
        }

        public IList<Photo> ListPhoto()
        {
            return _repo.Query<Photo>().ToList();
        }



    }
}