using System;
namespace PhotoAlbum.Service
{
    public interface IAlbumService
    {
        void CreateAlbum(PhotoAlbum.Models.Album album);
        void EditAlbum(PhotoAlbum.Models.Album album);
        PhotoAlbum.Models.Album FindAlbum(int id);
        System.Collections.Generic.IList<PhotoAlbum.Models.Album> ListAlbums();
        System.Collections.Generic.IList<PhotoAlbum.Models.Photo> ListPhoto();
    }
}
