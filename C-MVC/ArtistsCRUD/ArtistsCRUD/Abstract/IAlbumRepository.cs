using ArtistsCRUD.Models;
using ArtistsCRUD.Services;
using System.Collections.Generic;

namespace ArtistsCRUD.Abstract
{
    public interface IAlbumRepository
    {
        ResponseObject CreateArtists(AlbumModel albumModel);
        ResponseObject DeleteArtists(string id);
        ResponseObject UpdateArtists(AlbumModel albumModel);

        object GetAlbums();
        object GetArtist(string id);
    }
}
